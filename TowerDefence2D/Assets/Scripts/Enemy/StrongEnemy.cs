using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrongEnemy : Enemy
{

    protected override void Start()
    {
        base.Start();
        SetHealthRef(200);
    }
}