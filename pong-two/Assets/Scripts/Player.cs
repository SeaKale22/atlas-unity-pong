using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Paddle
{
    public KeyCode upKey;
    public KeyCode downKey;
    public GameObject pauseCanvas;

    // Start is called before the first frame update
    void Start()
    {
        // Time.timeScale = 0.25f;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
        if (Input.GetKeyUp(KeyCode.Escape) && this.gameObject.name == "Player One")
        {
            if (pauseCanvas.activeSelf)
            {
                Time.timeScale = 1f;
                pauseCanvas.SetActive(false);
            }
            else
            {
                Time.timeScale = 0;
                pauseCanvas.SetActive(true);
            }
        }   
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
