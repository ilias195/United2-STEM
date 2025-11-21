using UnityEngine;

public class endLessRunner : MonoBehaviour
{
    [SerializeField] float _vbegin = 4f;
    [SerializeField] float _g = -5f;
    float _t = 0f;
    float _tMax = 0.867f;

    [SerializeField] GameObject _gameObject;
    Animator animator;

    enum State { running, jumping};
    State mystate = State.running;

    Vector3 velocity = Vector3.zero;
    Vector3 acceleration = Vector3.zero;

    private void Start()
    {
        animator = _gameObject.GetComponent<Animator>();
    }

    private void Update()
    {
        if (mystate == State.running)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                animator.Play("Jump");
                velocity = new Vector3(0,_vbegin,0);
                _g = -2 * _vbegin / _tMax;
                acceleration = new Vector3(0,_g,0);

                _t = 0f;

                mystate = State.jumping;
            }
        }
        if (mystate == State.jumping)
        {
            _t += Time.deltaTime;
            if (_t > _tMax)
            {
                mystate = State.running;
                velocity = Vector3.zero;
                acceleration = Vector3.zero;
            }
          
        }

        velocity += acceleration * Time.deltaTime;
        transform.position += velocity * Time.deltaTime;

   
    }
}
