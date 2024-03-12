using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float ballSpeed;
    public float ballSpeedIncrementer;

    private float ballSpeedIncreasing;
    private Rigidbody2D ballRigidbody;
    private RectTransform ballTransform;
    public ScoreTracker ScoreTracker;
    
    
    // Start is called before the first frame update
    void Start()
    {
        // set ball speed increasing
        ballSpeedIncreasing = ballSpeed;
        // get ball's rigid body
        ballRigidbody = GetComponent<Rigidbody2D>();
        ballTransform = GetComponent<RectTransform>();
        // launch ball in random direction after a delay
        Invoke(nameof(BallReset), 3);
    }

    void OnTriggerEnter2D(Collider2D Collision)
    {
        // Collision response to hitting a paddle, should bounce ball in opposite direction
        if (Collision.gameObject.CompareTag("Paddle"))
        {
            // Get Paddle tansform
            RectTransform paddleTransform = Collision.GetComponent<RectTransform>();
            //calculate angle
            float y = launchAngle(ballTransform.anchoredPosition, paddleTransform.anchoredPosition, paddleTransform.sizeDelta.y / 2f);
            //set angle and speed
            float x = ballRigidbody.velocity.x < 0 ? 1.0f : -1.0f;
            Vector2 direction = new Vector2(x, y).normalized;
            ballRigidbody.velocity = direction  * ballSpeedIncreasing;

            // increase ball speed
            ballSpeedIncreasing += ballSpeedIncrementer;
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

            // reset ball speed
            ballSpeedIncreasing = ballSpeed;
        }
    }

    //calculates the angle the ball hits the paddle at
    float launchAngle(Vector2 ballPosition, Vector2 paddlePosition, float paddleHeight)
    {
        return (ballPosition.y - paddlePosition.y) / (paddleHeight / 2);
    }
    
    void BallReset()
    {
        float xValue = Random.value;
        float yValue = Random.Range(-250f, 250f);
        if (xValue >= 0.5f)
        {
            xValue = Mathf.Lerp(35, 250, xValue);
        }
        else
        {
            xValue = Mathf.Lerp(-250, -35, xValue);
        }
        ballRigidbody.velocity = new Vector2(xValue, yValue).normalized * ballSpeed;
        Debug.Log($"X : {xValue}\nY : {yValue}");
    }
}
