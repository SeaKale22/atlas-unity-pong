using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class AIPlayer : MonoBehaviour
{
    public GameObject ball;
    public int difficulty;
    
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
        if (difficulty == 1)
        {
            LevelOneMove();
        }
        if (difficulty == 2)
        {
            LevelTwoMove();
        }
        if (difficulty == 3)
        {
            LevelThreeMove();
        }
    }

    void LevelOneMove()
    {
        if (ball.transform.localPosition.x >= 0 && ballRigidbody.velocity.x > 0)
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
    void LevelThreeMove()
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
