using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DifficultyControl : MonoBehaviour
{
    public AIPlayer AIPlayer;
    public GameObject DifficultyCanvas;
    
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DifficultyOn()
    {
        AIPlayer.difficulty = true;
        Time.timeScale = 1;
        DifficultyCanvas.SetActive(false);
    }
    
    public void DifficultyOff()
    {
        AIPlayer.difficulty = false;
        Time.timeScale = 1;
        DifficultyCanvas.SetActive(false);
    }
    
    public void GoToMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
