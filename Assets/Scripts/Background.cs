using UnityEngine;

public class Background : MonoBehaviour
{
    private Transform playerTransform;

    void Start()
    {
        playerTransform = GameObject.Find("Player").transform;
    }

    void Update()
    {
        // Keep background at same X/Y as player, but behind in Z
        transform.position = new Vector3(
            playerTransform.position.x,
            playerTransform.position.y,
            transform.position.z // keep original Z
        );
    }
}

