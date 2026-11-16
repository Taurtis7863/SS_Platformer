using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UIElements;

public class PlatformerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    private float moveDir = 0;
    public float knockbackForce = 10f;
    private Rigidbody2D rb;

    private bool isGrounded = false;
    private bool onPlatform = false;
    private bool gettingKnockBack = false;
    public Transform groundCheck;
    public float groundCheckRadius = .2f;
    public LayerMask groundLayer;
    public LayerMask platformLayer;
    public GameObject CoinPlayer;
    public GameObject HurtPlayer;
    public GameObject JumpPlayer;

    private Animator animator;
    private SpriteRenderer sprite;
    private Vector3 spawnLocation;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator =GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        spawnLocation = transform.position;
    }


    void Update()
    {
        if (Input.GetKey(KeyCode.A)) moveDir = -1; //left
        if (Input.GetKey(KeyCode.D)) moveDir = 1; //Right

        if (
            (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D)) || //Pressing None
            (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D)) //Pressing Both
            ) moveDir = 0;

       if(!gettingKnockBack) rb.linearVelocity = new Vector2(moveDir * moveSpeed, rb.linearVelocity.y);
        if (rb.linearVelocity.x < 0) sprite.flipX = true;
        else if (rb.linearVelocity.x > 0) sprite.flipX = false;

        animator.SetFloat("Speed", Mathf.Abs(rb.linearVelocity.x));
        if (isGrounded || onPlatform) animator.SetBool("IsJumping", false);
        else animator.SetBool("IsJumping", true);

        if (Input.GetKeyDown(KeyCode.Space) && (isGrounded || onPlatform))
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            GameObject temp = Instantiate(JumpPlayer, transform.position, Quaternion.identity);
            Destroy(temp, 1.0f);
        }
        if (transform.position.y < -7)
        {
            transform.position = spawnLocation;
        }
    }
    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        onPlatform = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, platformLayer);
       
        Collider2D platform = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, platformLayer);
        if (onPlatform) transform.SetParent(platform.transform);
        else transform.SetParent(null);

        if (isGrounded) gettingKnockBack = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            GameObject temp = Instantiate(CoinPlayer, transform.position, Quaternion.identity);
            Destroy(temp, 1.0f);
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("Enemy") && (isGrounded || onPlatform))
        {

            gettingKnockBack = true;
            if (collision.transform.position.x < transform.position.x)
            {

                rb.linearVelocity = new Vector2(knockbackForce, knockbackForce);

            }
            else
            {
                rb.linearVelocity = new Vector2(-knockbackForce, knockbackForce);
            }
            GameObject temp = Instantiate(HurtPlayer, transform.position, Quaternion.identity);
            Destroy(temp, 1.0f);
        }
        else if (collision.gameObject.CompareTag("projectile"))
        {

            gettingKnockBack = true;
            if (collision.transform.position.x < transform.position.x)
            {

                rb.linearVelocity = new Vector2(knockbackForce, knockbackForce);

            }
            else
            {
                rb.linearVelocity = new Vector2(-knockbackForce, knockbackForce);
            }
            GameObject temp = Instantiate(HurtPlayer, transform.position, Quaternion.identity);
            Destroy(temp, 1.0f);
        }

    }

}
