using UnityEngine;

public class FootCollider : MonoBehaviour
{
    public float jumpForce = 10f;
    private Rigidbody2D player;
    void Start()
    {
        player = GetComponentInParent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy") && player.linearVelocity.y < 0)
        {
            player.linearVelocity = new Vector2(player.linearVelocity.x, jumpForce);
            if (collision.GetComponent<EnemyPatrol>())
            {
                collision.GetComponent<EnemyPatrol>().GotHit();
            }
        }
    }
}
