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

    private int currentIndex = 0;
    private int direction = 1;

    protected override void EnemyBehaviour()
    {
        float distance = Vector2.Distance(transform.position, player.position);

        // reset states
        isChasing = false;
        isAttacking = false;

        if (distance <= attackRange)
        {
            isChasing = true;
            isAttacking = true;
        }
        else if (distance <= chaseRange)
        {
            isChasing = true;
            Chase();
        }
        else
        {
            Patrol();
        }
    }

    private void Patrol()
    {
        if (waypoints.Length < 2) return;

        Transform target = waypoints[currentIndex];

        transform.position = Vector2.MoveTowards(
            transform.position,
            target.position,
            patrolSpeed * Time.deltaTime
        );

        if (Vector2.Distance(transform.position, target.position) < 0.05f)
        {
            if (currentIndex == waypoints.Length - 1)
                direction = -1;
            else if (currentIndex == 0)
                direction = 1;

            currentIndex += direction;
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