using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float followSpeed = 2f;
    public Transform target;
    public float yOffset = -4;

    void Update()
    {
        Vector3 newPos = new Vector3(target.position.x, target.position.y +yOffset, -10f);
        transform.position = Vector3.Slerp(transform.position, newPos, followSpeed * Time.deltaTime);
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -.9f, 10000f), -10f);
    }
}
