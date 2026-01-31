using Unity.VisualScripting;
using UnityEngine;

public abstract class EnemyBase : MonoBehaviour
{
    protected Animator animator;
    protected Rigidbody2D rb;
    protected Transform player;

    [SerializeField] protected float dectectionRange = 3f;

    protected bool playerInRange;

    public virtual void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    protected virtual void Update()
    {
        EnemyDetection(); //zoek voor player
        EnemyBehavoiur(); // voert gedraf uit

        
    }

    public virtual void  EnemyDetection()
    {
        float distance  = Vector2.Distance(transform.position, player.position);
        playerInRange = distance <= dectectionRange;
    }

    public virtual void EnemyBehavoiur()
    {
        
    }

   

}
