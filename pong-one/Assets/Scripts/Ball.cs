using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float ballSpeed;
    private Rigidbody2D ballRigidbody;
    
    
    // Start is called before the first frame update
    void Start()
    {
        // get ball's rigid body
        ballRigidbody = GetComponent<Rigidbody2D>();
        // launch ball in random direction
        ballRigidbody.velocity = Random.insideUnitCircle * ballSpeed;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D Collision)
    {
        // Collision response to hitting a paddle, should bounce ball in opposite direction
        if (Collision.gameObject.CompareTag("Paddle"))
        {
            // inverse velocity
            ballRigidbody.velocity *= -1;
            
        }
    }

    void BallReset()
    {
        ballRigidbody.velocity = new Vector2(0, 0);
        transform.position = new Vector3(0, 0, 0);
        ballRigidbody.velocity = Random.insideUnitCircle * ballSpeed;
    }
}
