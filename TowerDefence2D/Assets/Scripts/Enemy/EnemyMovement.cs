using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private float speed = 1f;

    private Transform target;
    private int waypointIndex = 0;

    private bool isDead = false; // Flag to check if the enemy is dead

    void Start()
    {
        target = Waypoints.points[0];
    }

    private void Update()
    {
        if (!isDead) // Only move if the enemy is not dead
        {
            MoveTowardsWaypoint();
        }
    }

    void MoveTowardsWaypoint()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            GetNextWaypoint();
        }
    }

    void GetNextWaypoint()
    {
        if (waypointIndex >= Waypoints.points.Length - 1)
        {
            return;
        }
        waypointIndex++;
        target = Waypoints.points[waypointIndex];
    }

    // Method to set the death state
    public void SetDeadState(bool state)
    {
        isDead = state;
    }
}
