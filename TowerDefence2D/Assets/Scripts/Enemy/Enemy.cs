using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float currentHealth;
    private float health = 100f;
    protected bool isDied = false;

    
    Manager manager;
    [SerializeField] GameObject healthBar;
    Tower tower;
    Animator animator;

    private bool diedFromPoison = false;
    private float poisonTimer = 0f;
    private float poisonDamage = 10f;

    protected virtual void Start()
    {
        tower = FindObjectOfType<Tower>();
        manager = GameObject.Find("Manager").GetComponent<Manager>();
        currentHealth = health;

        // Animator bileþenini al
        animator = GetComponent<Animator>();
    }

    protected void SetHealthRef(float healthRef)
    {
        health = healthRef;
    }

    private void Update()
    {
        if (poisonTimer > 0)
        {
            poisonTimer -= Time.deltaTime;
            PoisonDamage();
        }

    }

    private void PoisonDamage()
    {
        currentHealth -= poisonDamage * Time.deltaTime;
        healthBar.transform.localScale = new Vector3(currentHealth / health, healthBar.transform.localScale.y);

        if (currentHealth <= 0 && !diedFromPoison)
        {
            diedFromPoison = true;
            Die();
        }
    }

    public void ApplyPoison(float duration, float damagePerSecond)
    {
        poisonTimer = duration;
        poisonDamage = damagePerSecond;
    }

    public void SetTowerReference(Tower towerRef)
    {
        tower = towerRef;
    }

    public void Damage()
    {
        float damage = tower.GetTowerDamage();
        currentHealth -= damage;
        healthBar.transform.localScale = new Vector3(currentHealth / health, healthBar.transform.localScale.y);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    // Yeni metod: Ölme iþlemleri
    protected virtual void Die()
    {
        if (EnemyList.enemies.Contains(this.gameObject))
        {
            EnemyList.enemies.Remove(this.gameObject);
        }
        if (isDied) return; // Eðer zaten öldüyse tekrar ölme iþlemi yapma

        isDied = true;
        healthBar.SetActive(false);

        if (animator != null)
        {
            animator.SetBool("isDead", true);
            // Stop enemy movement when dead
            GetComponent<EnemyMovement>().SetDeadState(true);
        }

        manager.money += 25f;

        StartCoroutine(DestroyAfterAnimation());
    }

    // Animasyon bitimini bekleyen metod
    private IEnumerator DestroyAfterAnimation()
    {
        yield return new WaitForSeconds(1f); 
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null)
        {
            if (collision.gameObject.tag == "Bullet")
            {
                Damage();
                Destroy(collision.gameObject);
            }
            if (collision.gameObject.tag == "EndPoint")
            {
                EnemyList.enemies.Remove(this.gameObject);
                Destroy(this.gameObject);
                manager.health -= 1f;
                Debug.Log(manager.health);
                if (manager.health <= 0)
                {
                    Debug.Log("Game Over");
                }
            }
        }
    }
}
