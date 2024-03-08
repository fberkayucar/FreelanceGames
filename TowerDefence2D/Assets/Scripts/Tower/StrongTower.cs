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

    // Di�er kodlar...

    protected override void Shoot()
    {
        base.Shoot();
        // Sadece ate� etme durumunda zehir hasar� uygula
        SetPoisonDamage(16f); // Zehir hasar�n� ayarla (�rne�in 10)
    }
}
