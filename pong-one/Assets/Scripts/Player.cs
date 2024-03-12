using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Paddle
{
    public KeyCode upKey;
    public KeyCode downKey;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
    }

    void PlayerMove()
    {
        if (Input.GetKey(upKey))
        {
            MoveUp();
        }
        if (Input.GetKey(downKey))
        {
            MoveDown();
        }
    }
}
