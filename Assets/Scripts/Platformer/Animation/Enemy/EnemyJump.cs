using UnityEngine;

public class EnemyJump : EnemyBase
{
    [SerializeField] private float jumpForce = 6f;

    private bool hasJumped;

    protected override void EnemyBehaviour()
    {
        if (playerInRange)
        {
            animator.SetBool("IsWalking", false);

            // springt maar één keer per detectie
            if (!hasJumped)
            {
                Jump();
                animator.SetTrigger("Attack");
                hasJumped = true;
            }
        }
        else
        {
            // reset wanneer player weg is
            hasJumped = false;
            animator.SetBool("IsWalking", true);
        }
    }

    private void Jump()
    {
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        animator.SetTrigger("Jump");
    }
}
