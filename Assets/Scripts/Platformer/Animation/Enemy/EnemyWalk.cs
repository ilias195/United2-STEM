using UnityEngine;

public class EnemyWalk : EnemyBase
{
    protected override void EnemyBehaviour()
    {
        if (playerInRange)
        {
            animator.SetBool("IsWalking", false);
            animator.SetTrigger("Attack");
        }
        else
        {
            animator.SetBool("IsWalking", true);
        }
    }
}
