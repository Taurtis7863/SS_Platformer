using UnityEngine;
using UnityEngine.InputSystem.Processors;

public class EnemyPatrol : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private Animator animator;
    public Transform pointLeft;
    public Transform pointRight;
    public GameObject EnemyDeathPlayer;

    public float speed = 4;
    public bool takingDamage = false;
    public bool isDead = false;
    private Transform currentPoint;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        currentPoint = pointRight.transform;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 point = currentPoint.position - transform.position;
        if (!takingDamage)
        {
            if (currentPoint == pointRight) rb.linearVelocity = new Vector2(speed, rb.linearVelocity.y);
            else rb.linearVelocity = new Vector2(-speed, rb.linearVelocity.y);
        }
        else
        {
            rb.linearVelocity = new Vector2(0, rb.linearVelocity.y);
        }
        if (isDead) Destroy(gameObject);

        if(Mathf.Abs(transform.position.x - currentPoint.position.x) < 0.5f)
        {
            if (currentPoint == pointRight)
            {
                currentPoint = pointLeft;
                sprite.flipX = true;
            }
            else
            {
                currentPoint = pointRight;
                sprite.flipX = false;
            }
        }
    }
    public void GotHit()
    {
        animator.Play("EnemyDeath");
        GameObject temp = Instantiate(EnemyDeathPlayer, transform.position, Quaternion.identity);
        Destroy(temp, 1.0f);
    }
}
