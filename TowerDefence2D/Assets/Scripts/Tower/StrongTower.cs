using UnityEngine;

public class StrongTower : Tower
{
    private float additionalDamage = 5f;

    public Transform arrowLocation;

    protected override void Start()
    {
        base.Start();
        ThrowLocationRef(arrowLocation);
        SetTowerDamage(additionalDamage);
        SetTowerRange(5f);
        SetTowerFireRate(1f);
    }

    // Diðer kodlar...

    protected override void Shoot()
    {
        base.Shoot();
        // Sadece ateþ etme durumunda zehir hasarý uygula
        SetPoisonDamage(16f); // Zehir hasarýný ayarla (örneðin 10)
    }
}
