using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    [SerializeField] private GameObject GameOverPanel;
    private string gameScene = "Game";

    private void Start()
    {
        GameManager.onGameOver += GameOver;
    }
    private void GameOver()
    {
        GameOverPanel.SetActive(true);
    }
    public void Restart()
    {
        GameManager.onGameOver -= GameOver;

        GameManager.Instance.StartCoroutine(GameManager.transitionScene(gameScene));
    }

    public void Exit()
    {
        Application.Quit();
    }
}
