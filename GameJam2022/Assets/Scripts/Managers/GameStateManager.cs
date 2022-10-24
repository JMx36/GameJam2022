using UnityEngine;
using UnityEngine.SceneManagement;


public class GameStateManager : MonoBehaviour
{
    private static GameStateManager manager;

    private static int high_score = 0;

    public static int candies = 0; 

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
        candies = 0;
        Enemy_BehaviorTree.stealIncrease = 10;
        Enemy_BehaviorTree.stealAmount = 10;
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
        candies += points;

        // If high score is less than or equal to candies plus points,
        // then it adds the difference of high score and cadies to high score. 

        if (high_score <= candies)
        {
            int difference = candies - high_score;
            high_score += difference;
        }
    }

    public void LosePoints(int points)
    {
        // If the amount of candies is less than or equal to the ones being taken away, then it loads the EndScene. 
        // Substracts the points (or amount of candy) from candies if not.
        if (candies <= points)
        {
            GameStateManager.EndScene(); //TODO Change the name to the actual one
        }
        else
        {
            candies -= points;
        }
    }

    public static void Quit()
    {
        Debug.Log("Quitting");
        PlayerPrefs.SetInt("HighScore", high_score);
        Application.Quit();
    }

}
