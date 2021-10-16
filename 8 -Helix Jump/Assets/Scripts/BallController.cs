using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    private bool ignoreNextCollision;
    public Rigidbody rb;
    public float impulseForce = 5f;
    private Vector3 startPosition;

    public int perfectPass = 0;
    public bool isSuperSpeedActive;


    void Awake()
    {
        startPosition = transform.position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (ignoreNextCollision)
            return;

        if(isSuperSpeedActive)
        {
            if(!collision.transform.GetComponent<GoalBehaviour>())
            {
                Destroy(collision.transform.parent.gameObject);
                Debug.Log("Destroying platform");
            }
        }
        else
        {
            // Adding ResetLevel functionality via DeathPart - initialized
            // when deathpart is hit
            DeathPart deathPart = collision.transform.GetComponent<DeathPart>();
            if (deathPart)
                deathPart.HitDeathPart();
        }



        //Debug.Log("Ball Touched Something");
        rb.velocity = Vector3.zero;
        rb.AddForce(Vector3.up * impulseForce, ForceMode.Impulse);

        ignoreNextCollision = true;
        Invoke("AllowCollision", .2f);

        perfectPass = 0;
        isSuperSpeedActive = false;
    }

    public void Update()
    {
        if (perfectPass >= 2 && !isSuperSpeedActive)
        {
            isSuperSpeedActive = true;
            rb.AddForce(Vector2.down * 10, ForceMode.Impulse);
        }
    }

    private void AllowCollision()
    {
        ignoreNextCollision = false;
    }

    public void ResetBall()
    {
        transform.position = startPosition;
    }
}
