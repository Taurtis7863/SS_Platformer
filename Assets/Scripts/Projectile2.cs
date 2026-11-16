using UnityEngine;

public class Projectile2 : MonoBehaviour
{
    public float speed = 6;
    void Update()
    {
        transform.Translate(-transform.right * speed * Time.deltaTime);
        if (transform.position.x < 84)
        {
            Destroy(gameObject);
        }

    }
}
