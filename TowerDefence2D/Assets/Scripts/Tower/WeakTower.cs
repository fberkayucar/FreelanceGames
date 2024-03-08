using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeakTower : Tower
{
    private float additionalDamage = 10f;
    [SerializeField] Transform arrowLocation;
    protected override void Start()
    {
        base.Start();
        ThrowLocationRef(arrowLocation);
        SetTowerDamage(1f + additionalDamage);
        SetTowerRange(5f);
        SetTowerFireRate(1f);

    }
}
