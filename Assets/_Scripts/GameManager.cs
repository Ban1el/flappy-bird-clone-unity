using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverUI;
    private void OnEnable()
    {
        Actions.OnHit += GameOver;
        Actions.OnClick += StartGame;
    }

    private void OnDisable()
    {
        Actions.OnHit -= GameOver;
        Actions.OnClick -= StartGame;
    }

    public void GetReady()
    {
        Actions.SetUI?.Invoke("start_menu", false);
        Actions.SetUI?.Invoke("get_ready", true);
    }

    public void StartGame(string button_name)
    {
        if (button_name == "start_game")
        {
            GetReady();

            Actions.OnEnablePlayerMovement?.Invoke();
        }
    }

    public void GameOver()
    {
        gameOverUI.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
}
