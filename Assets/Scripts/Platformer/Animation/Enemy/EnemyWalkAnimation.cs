using UnityEditor;
using UnityEngine;

public class EnemyWalkAnimation :MonoBehaviour

{
    private Animator animator;
    private EnemyWalk enemy;

    private float attackTimer;
    public float attackCooldown = 1f;

    void Awake()
    {
        animator = GetComponent<Animator>();
        enemy = GetComponent<EnemyWalk>();
    }

    void Update()
    {
        if (enemy == null) return;

        // Chase animatie
        animator.SetBool("IsChasing", enemy.isChasing);

        // Attack animatie
        if (enemy.isAttacking)
        {
            attackTimer += Time.deltaTime;

            if (attackTimer >= attackCooldown)
            {
                animator.SetTrigger("Attack");
                attackTimer = 0f;
            }
        }
        else
        {
            attackTimer = attackCooldown; // meteen klaar voor volgende attack
        }
    }
}

