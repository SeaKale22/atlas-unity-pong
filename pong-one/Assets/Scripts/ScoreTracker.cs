using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreTracker : MonoBehaviour
{
    public TMP_Text leftScore;
    public TMP_Text rightScore;
    public TMP_Text WinnerText;
    
    public int winScore;
    public GameObject winCanvas;
    public GameObject ball;
  
    
    private int playerOneScore = 0;
    private int playerTwoScore = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate()
    {
        if (playerOneScore == winScore)
        {
            ActivateWinScreen(1);
        }

        if (playerTwoScore == winScore)
        {
            ActivateWinScreen(2);
        }
    }

    public void PlayerOneScores()
    {
        playerOneScore++;
        leftScore.text = playerOneScore.ToString();
    }

    public void PlayerTwoScores()
    {
        playerTwoScore++;
        rightScore.text = playerTwoScore.ToString();
    }

    void ActivateWinScreen(int winner)
    {
        ball.SetActive(false);
        if (winner == 1)
        {
            WinnerText.text = "Player One Wins!";
        }
        else
        {
            WinnerText.text = "Player Two Wins!";
        }
        winCanvas.SetActive(true);
    }
}
