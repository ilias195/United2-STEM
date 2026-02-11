
using Unity.VisualScripting;
using UnityEngine;

public abstract class EnemyBase1 : MonoBehaviour
{
    protected Transform player;
    protected Animator animator;

    [Header("Detection")]
    [SerializeField] protected float detectionRange = 5f;

    protected bool isDead = false;

    protected virtual void Awake()
    {
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    protected virtual void Update()
    {
        if (isDead) return;

        EnemyBehaviour();
    }

    protected abstract void EnemyBehaviour();

    // Wordt aangeroepen als enemy doodgaat
    public virtual void Die()
    {
        if (isDead) return;

        isDead = true;

        

        Destroy(gameObject, 0.1f);
    }

}
