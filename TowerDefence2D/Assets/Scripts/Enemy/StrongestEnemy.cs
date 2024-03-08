using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrongestEnemy : Enemy
{
    protected override void Start()
    {
        base.Start();
        SetHealthRef(300);
    }
}
