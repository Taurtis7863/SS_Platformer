using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float speed = 2f;
    public Vector2 pos1;
    public Vector2 pos2;
    
    public Vector3 currentPosition;
    private Vector3 pos1_vec, pos2_vec;
    private Rigidbody2D rb;
    void Start()
    {
        pos1_vec = new Vector3(pos1.x, pos1.y, 0);
        pos2_vec = new Vector3(pos2.x, pos2.y, 0);
        currentPosition = pos1_vec;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.Lerp(transform.position, currentPosition, speed * Time.deltaTime);
        if (Vector3.Distance(transform.position, currentPosition) < .5f)
        {
            if (currentPosition == pos1_vec) currentPosition = pos2_vec;
            else currentPosition = pos1_vec;
        }
    }
}
