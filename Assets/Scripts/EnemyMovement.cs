using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : Movement
{
    [SerializeField] protected Vector3 direction;

    protected override void Move()
    {
        rb.velocity = direction.normalized * speed;
    }
}
