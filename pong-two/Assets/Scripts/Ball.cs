using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class Ball : MonoBehaviour
{
    public float ballSpeed;
    public float ballSpeedIncrementer;
    public AudioClip goalPing;
    public AudioClip paddlePing;
    public AudioClip wallPing;

    private AudioSource ballAudio;
    private float bounceCount = 0;
    private float ballSpeedIncreasing;
    private Rigidbody2D ballRigidbody;
    private RectTransform ballTransform;
    public ScoreTracker ScoreTracker;
    private ParticleSystem ballParticles;
    
    // color values
    private float red = 1;
    private float green = 1;
    private float blue = 0.6773585f;
    private float alpha = 0.1f;
    
    // Start is called before the first frame update
    void Start()
    {
        // get ball particle system
        ballParticles = GetComponent<ParticleSystem>();
        // get ball AudioScorce
        ballAudio = GetComponent<AudioSource>();
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
            // play audio
            RandomPitch();
            ballAudio.clip = paddlePing;
            ballAudio.Play();
            
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
            
            // increase ball bounce count
            bounceCount += 1;
            Debug.Log($"bounceCount: {bounceCount}");
            
            // change particle properties
            ChangeParticles(bounceCount);
        }
        if (Collision.gameObject.CompareTag("Wall"))
        {
            // play audio
            RandomPitch();
            ballAudio.clip = wallPing;
            ballAudio.Play();
            
            // inverse y velocity
            float ballVelocityY = ballRigidbody.velocity.y * -1;
            ballRigidbody.velocity = new Vector2(ballRigidbody.velocity.x, ballVelocityY);

        }

        if (Collision.gameObject.CompareTag("Goal"))
        {
            // play audio
            RandomPitch();
            ballAudio.volume = 0.3f;
            ballAudio.clip = goalPing;
            ballAudio.Play();
            ballAudio.volume = 1f;
            
            //adjust score
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
            
            // reset bounce count
            bounceCount = 0;
            
            // change particles
            ChangeParticles(bounceCount);
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

    void RandomPitch()
    {
        ballAudio.pitch = Random.Range(0.8f, 1.2f);
    }

    void ChangeParticles(float count)
    {
        var main = ballParticles.main;
        switch (count)
        {
            case 0:
                red = 1;
                green = 1;
                blue = 0.6773585f;
                alpha = 0.1f;
                main.startSize = 5;
                main.startColor = new Color(red, green, blue, alpha);
                break;
            default:
                main.startSize =
                    new ParticleSystem.MinMaxCurve(main.startSize.constantMin + 1, main.startSize.constantMax);
                green -= 0.1f;
                blue -= 0.05f;
                alpha += 0.05f;
                main.startColor = new Color(red, green, blue, alpha);
                break;
        }
    }
}
