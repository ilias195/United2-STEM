
using UnityEngine;

public abstract class EnemyBase : MonoBehaviour
{
    protected Animator animator;
    protected Rigidbody2D rb;
    protected Transform player;

    [SerializeField] protected float detectionRange = 3f;
    protected bool playerInRange;

    protected virtual void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    protected virtual void Update()
    {
        DetectPlayer();
        EnemyBehaviour();
    }

   
    protected void DetectPlayer()
    {
        float distance = Vector2.Distance(transform.position, player.position);
        playerInRange = distance <= detectionRange;
    }

   
    protected abstract void EnemyBehaviour();

}
