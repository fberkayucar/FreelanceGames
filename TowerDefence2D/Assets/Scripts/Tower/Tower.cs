using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    protected float damage;
    protected float range;
    protected float rotationSpeed = 5f;
    public Transform target;
    protected float fireRate;
    private float fireCountdown = 0f;
    [SerializeField] protected Bullet bullet;
    public GameObject bulletPrefab;
    private Transform throwLocation;
    protected float poisonDamage = 0f;
    private WeakArcher weakArcher;
    private StrongArcher strongArcher;

    protected virtual void Start()
    {
        weakArcher = GetComponentInChildren<WeakArcher>();
        strongArcher = GetComponentInChildren<StrongArcher>(); 
        InvokeRepeating("UpdateTarget", 0f, .3f);
    }

    public void UpdateTarget()
    {
        if (target == null || Vector2.Distance(transform.position, target.position) > range)
        {
            target = FindNewTarget();

            // Hedef deðiþtiðinde WeakArcher scriptine yeni hedefi ileten kod
            if (weakArcher != null)
            {
                weakArcher.target = target;
            }
            if (strongArcher != null)
            {
                strongArcher.target = target;
            }
        }

        if (target != null)
        {
            if (fireCountdown <= 0f)
            {
                Shoot();
                fireCountdown = 1f / fireRate;

                // Düþman varsa ve isShooting true ise animasyonu baþlat
                if (weakArcher != null)
                {
                    weakArcher.isShooting = true; // Animasyonu baþlat
                }
                if (strongArcher != null)
                {
                    strongArcher.isShooting = true; // Animasyonu baþlat
                }
            }
        }
        else
        {
            // Eðer yakýnýnda düþman yoksa isShooting false yap
            if (weakArcher != null)
            {
                weakArcher.isShooting = false; // Animasyonu durdur
            }
            if (strongArcher != null)
            {
                strongArcher.isShooting = false; // Animasyonu durdur
            }
        }
    }

    public void ThrowLocationRef(Transform towerRef)
    {
        throwLocation = towerRef;
    }

    protected Transform FindNewTarget()
    {
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in EnemyList.enemies)
        {
            if (enemy != null)
            {
                float distanceToEnemy = Vector2.Distance(transform.position, enemy.transform.position);

                if (distanceToEnemy < shortestDistance && distanceToEnemy <= range)
                {
                    shortestDistance = distanceToEnemy;
                    nearestEnemy = enemy;

                    nearestEnemy.GetComponent<Enemy>().SetTowerReference(this);
                }
            }
        }

        return nearestEnemy != null ? nearestEnemy.transform : null;
    }

    protected void Update()
    {
        if (fireCountdown > 0f)
        {
            fireCountdown -= Time.deltaTime;
        }

        if (target != null)
        {
            // Zehir etkisi uygula
            if (poisonDamage > 0)
            {
                target.GetComponent<Enemy>().ApplyPoison(5f, poisonDamage); // 5 saniye boyunca her saniye zehir hasarý uygula
                poisonDamage = 0f; // Zehir etkisini sýfýrla
            }

            // Diðer kodlar...
        }
    }

    protected void SetPoisonDamage(float newPoisonDamage)
    {
        poisonDamage = newPoisonDamage;
    }

    protected void SetTowerRange(float newRange)
    {
        range = newRange;
    }

    protected void SetTowerDamage(float newDamage)
    {
        damage = newDamage;
    }

    protected void SetTowerFireRate(float newFireRate)
    {
        fireRate = newFireRate;
    }

    protected void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }

    protected virtual void Shoot()
    {
        if (target != null)
        {
            GameObject bulletGO = Instantiate(bulletPrefab, throwLocation.position, Quaternion.identity);
            Bullet bullet = bulletGO.GetComponent<Bullet>();
            if (bullet != null)
            {
                bullet.SetTarget(target);
            }

            target.GetComponent<Enemy>().Damage();
        }
    }

    public float GetTowerDamage()
    {
        return damage;
    }
}
