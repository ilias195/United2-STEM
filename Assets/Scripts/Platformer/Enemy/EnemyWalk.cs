using UnityEngine;

public class EnemyWalk : EnemyBase1
{

   [Header("Waypoints")]
    public Transform[] waypoints;

    [Header("Ranges")]
    public float chaseRange = 5f;
    public float attackRange = 1.2f;

    [Header("Movement")]
    public float patrolSpeed = 2f;
    public float chaseSpeed = 3f;

    [HideInInspector] public bool isChasing;
    [HideInInspector] public bool isAttacking;

    private int index = 0;
    private int direction = 1;

    protected override void EnemyBehaviour()
    {
        float distance = Vector2.Distance(transform.position, player.position);

        if (distance <= attackRange)
        {
            isAttacking = true;
            isChasing = true;
            return;
        }

        if (distance <= chaseRange)
        {
            isChasing = true;
            isAttacking = false;
            Chase();
        }
        else
        {
            isChasing = false;
            isAttacking = false;
            Patrol();
        }
    }

    private void Patrol()
    {
        if (waypoints.Length < 2) return;

        Transform target = waypoints[index];

        transform.position = Vector2.MoveTowards(
            transform.position,
            target.position,
            patrolSpeed * Time.deltaTime
        );

        if (Vector2.Distance(transform.position, target.position) < 0.05f)
        {
            if (index == waypoints.Length - 1) direction = -1;
            if (index == 0) direction = 1;

            index += direction;
        }
    }

    private void Chase()
    {
        transform.position = Vector2.MoveTowards(
            transform.position,
            player.position,
            chaseSpeed * Time.deltaTime
        );
    }

}