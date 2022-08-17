using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject startButton;
    public Player player;
    public GameObject RestartButton;
    public GameObject ContinueButton;

    public bool gameIsPause;

    public Text gameOverCountdown;
    

    public Text playerScoure;
    public float scoure;
    // Start is called before the first frame update
    void Start()
    {
        gameIsPause = false;
        scoure = 0; 
        RestartButton.SetActive(false);
        ContinueButton.SetActive(false);
        
        Time.timeScale = 0;

    }

    // Update is called once per frame
    void Update()
    {
        if (player.isDead)
        {
            RestartButton.SetActive(true);
            ContinueButton.SetActive(true);
        }

        

        playerScoure.text = $"Scoure: {(scoure).ToString("0")}";

        if (player.scouceUp)
        {
            scoure++;
            playerScoure.text = $"Scoure: {(scoure).ToString("0")}";
            player.scouceUp = false;
        }
        

        
    }
    public void StartGame()
    {
        startButton.SetActive(false);
        Time.timeScale = 1;
    }
    public void GameOver()
    {
        Time.timeScale = 0;
    }
    public void RestartGame()
    {
        EditorSceneManager.LoadScene(0);
    }
    public void Continue()
    {
        Time.timeScale = 1;
    }
    public void PauseGame()
    {
        gameIsPause = !gameIsPause;
        if(gameIsPause)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }
}
