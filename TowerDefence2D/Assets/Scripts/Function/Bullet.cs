using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float speed = 30f;
    public float maxDistance = 20f;
    private int damage = 5;

    private Transform target;

    void Update()
    {
        MoveBullet();
    }

    public void SetTarget(Transform target)
    {
        this.target = target;
    }

    public void MoveBullet()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        // Hedefin yok edilip edilmediðini kontrol et
        if (target == null || target.Equals(null))
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame || distanceThisFrame >= maxDistance)
        {
            HitTarget();
            return;
        }

        float angle = Waypoints.GetAngleFromVectorFloat(dir);
        transform.eulerAngles = new Vector3(0, 0, angle - 90);
        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
    }

    void HitTarget()
    {
        // Mermi hedefine ulaþtýðýnda yapýlacak iþlemler buraya eklenir.
        // Örneðin, hedefe hasar verme veya diðer etkileþimler.
    }
}
