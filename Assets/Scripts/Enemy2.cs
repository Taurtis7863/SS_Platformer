using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class Enemy2 : MonoBehaviour
{
    private float BallWait;
    private float BallTimer;
    public GameObject Ball;
    public GameObject Ballshoot;
   
    void Update()
    {
        //Spawning
        BallTimer += Time.deltaTime;

        if(BallTimer > BallWait)
        {
            Instantiate(Ball, transform.position, Quaternion.identity);
            BallTimer = 0;
            BallWait = Random.Range(3f, 6f);

            GameObject temp = Instantiate(Ballshoot, transform.position, Quaternion.identity);
            Destroy(temp, 1.0f);
        }
    }
}
