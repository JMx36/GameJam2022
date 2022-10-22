using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameStateManager : MonoBehaviour
{
    private bool hasStarted = false;

    private static GameStateManager manager;

    private int high_score = 0;

    enum GAMESTATE
    {
        TITLESCREEN,
        PLAYING,
        PAUSED,
        WIN,
        LOSE
    }

    ///private static GAMESTATE state;

    private void Awake()
    {
        if (manager == null)
        {
            manager = this;
            DontDestroyOnLoad(manager);
        }
        else
        {
            Destroy(this);
        }

        if (PlayerPrefs.GetInt("HighScore") > 0)
        {
            manager.high_score = PlayerPrefs.GetInt("HighScore");
        }
        else
        {
            PlayerPrefs.SetInt("HighScore", 0);
        }
    }

    public static void TitleScreen()
    {
        ///state = GAMESTATE.TITLESCREEN;
    }

    public static void NewGame()
    {

        if (manager.hasStarted) 
        {
            SceneManager.LoadScene("Level1"); //TODO Change this to the actual name
        }
        else
        {
            SceneManager.LoadScene("TitleScreen"); //TODO Change this to the actual name
        }
    }

    public static void PauseRestart()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);

        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1.0f;
    }

    public static void PauseGame()
    {
        ///state = GAMESTATE.PAUSED;
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
    }


    public static void EndScene() 
    {
        SceneManager.LoadScene("EndScene");
    }

    
    public int getHighScore()
    {
        return manager.high_score;
    }
    
    public void AddPoints(int points)
    {
        manager.high_score += points;
    }

    public void LosePoints(int points)
    {
        if (manager.high_score < points)
        {
            SceneManager.LoadScene("EndScene"); //TODO Change the name to the actual one
        }
        else
        {
            manager.high_score -= points;
        }
    }

    public void Quit()
    {
        PlayerPrefs.SetInt("HighScore", manager.high_score);
        Application.Quit();
    }

}
