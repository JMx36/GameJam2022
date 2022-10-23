using UnityEngine;
using UnityEngine.SceneManagement;


public class GameStateManager : MonoBehaviour
{
    private static GameStateManager manager;

    private static int high_score = 0;

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
            high_score = PlayerPrefs.GetInt("HighScore");
        }
        else
        {
            PlayerPrefs.SetInt("HighScore", 0);
        }
    }

    public static void NewGame()
    {
        SceneManager.LoadScene("MAIN_SCENE"); //TODO Change this to the actual name
        Debug.Log("New Game");
    }

    public static void PauseRestart()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
        Time.timeScale = 1.0f;
    }

    public static void PauseGame(float time_value)
    {
        Time.timeScale = time_value;
    }


    public static void EndScene() 
    {
        SceneManager.LoadScene("End Scene");
    }

    
    public int getHighScore()
    {
        return high_score;
    }
    
    public void AddPoints(int points)
    {
        high_score += points;
    }

    public void LosePoints(int points)
    {
        if (high_score < points)
        {
            GameStateManager.EndScene(); //TODO Change the name to the actual one
        }
        else
        {
            high_score -= points;
        }
    }

    public static void Quit()
    {
        Debug.Log("Quitting");
        //PlayerPrefs.SetInt("HighScore", high_score);
        Application.Quit();
    }

}
