using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class AIPlayer : MonoBehaviour
{
    public GameObject ball;
    public bool difficulty;
    
    private Paddle parentPaddle;
    private Rigidbody2D ballRigidbody;
    
    // Start is called before the first frame update
    void Start()
    {
        parentPaddle = GetComponentInParent<Paddle>();
        if (GetComponentInParent<Player>())
        {
            Player playerScript = GetComponentInParent<Player>();
            playerScript.enabled = false;
        }

        ballRigidbody = ball.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        AIMovement();
    }

    void AIMovement()
    {
        if (difficulty == false)
        {
            LevelOneMove();
        }
        if (difficulty == true)
        {
            LevelTwoMove();
        }
    }

    void LevelOneMove()
    {
        if (ballRigidbody.velocity.x > 0)
        {
            if (ball.transform.localPosition.y > parentPaddle.transform.localPosition.y)
            {
                parentPaddle.MoveUp();
            }

            if (ball.transform.localPosition.y < parentPaddle.transform.localPosition.y)
            {
                parentPaddle.MoveDown();
            }
        }
    }
    void LevelTwoMove()
    {
        if (ball.transform.localPosition.y > parentPaddle.transform.localPosition.y)
        {
            parentPaddle.MoveUp();
        }

        if (ball.transform.localPosition.y < parentPaddle.transform.localPosition.y)
        {
            parentPaddle.MoveDown();
        }
    }
}
