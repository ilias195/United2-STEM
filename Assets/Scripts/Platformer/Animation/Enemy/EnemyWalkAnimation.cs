using UnityEditor;
using UnityEngine;

public class EnemyWalkAnimation :MonoBehaviour

{
    private Animator animator;
    private EnemyWalk enemy;

    private float lastAttackTime;
    [SerializeField] private float attackCooldown = 1f;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        enemy = GetComponent<EnemyWalk>();
    }

    private void Update()
    {
        if (enemy == null) return;

        animator.SetBool("IsChasing", enemy.isChasing);

        if (enemy.isAttacking && Time.time >= lastAttackTime + attackCooldown)
        {
            lastAttackTime = Time.time;
            animator.SetTrigger("Attack");
        }
        if (enemy.isAttacking)
        {
            Debug.Log("ATTACK SHOULD TRIGGER");
        }

    }
}

