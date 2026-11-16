using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Projectile : MonoBehaviour
{
    public float speed = 6;
    void Update()
    {
        transform.Translate(-transform.right * speed * Time.deltaTime);
        if (transform.position.x < -20)
        {
            Destroy(gameObject);
        }
    
    }
}


