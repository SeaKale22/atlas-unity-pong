using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float ballSpeed;
    private Rigidbody2D ballRigidbody;
    public ScoreTracker ScoreTracker;
    
    
    // Start is called before the first frame update
    void Start()
    {
        // get ball's rigid body
        ballRigidbody = GetComponent<Rigidbody2D>();
        // launch ball in random direction after a delay
        Invoke(nameof(BallReset), 3);
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
            //calculate angle
            float y = launchAngle(transform.position, Collision.transform.position, Collision.bounds.size.y);
            //set angle and speed
            Vector2 direction = new Vector2(ballRigidbody.velocity.x, y).normalized;
            ballRigidbody.velocity = (direction * -1) * ballSpeed;
            
            // // inverse velocity
            // ballRigidbody.velocity *= -1;
            
        }
        if (Collision.gameObject.CompareTag("Wall"))
        {
            // inverse y velocity
            float ballVelocityY = ballRigidbody.velocity.y * -1;
            ballRigidbody.velocity = new Vector2(ballRigidbody.velocity.x, ballVelocityY);

        }

        if (Collision.gameObject.CompareTag("Goal"))
        {
            if (Collision.gameObject.name == "LeftGoal")
            {
                ScoreTracker.PlayerTwoScores();
            }
            else
            {
                ScoreTracker.PlayerOneScores();
            }
            ballRigidbody.velocity = new Vector2(0, 0);
            transform.localPosition = new Vector3(0, 0, 0);
            Invoke(nameof(BallReset), 1);
        }
    }
    
    //calculates the angle the ball hits the paddle at
    float launchAngle(Vector2 ballPosition, Vector2 paddlePosition, float paddleHeight)
    {
        return (ballPosition.y - paddlePosition.y) / paddleHeight;
    }

    void BallReset()
    {
        ballRigidbody.velocity = new Vector2(Random.insideUnitCircle.x, Random.insideUnitCircle.y).normalized * ballSpeed;;
    }
}
