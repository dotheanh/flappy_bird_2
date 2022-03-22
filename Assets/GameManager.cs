using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public enum GameState
{
    Prepare,
    Started,
    Paused,
    Ended
}

public class GameManager : MonoBehaviour
{
    public GameObject guiPrepare;
    public PauseResumeController pauseResumeController;
    public GuiGameOver guiGameOver;
    public Player player;
    public GameState gameState;

    public ScoreCounter scoreCounter;
    public int score = 0;

    public ObstacleSpawner obstacleSpawner;

    // Start is called before the first frame update
    void Start()
    {
        gameState = GameState.Prepare;

        scoreCounter.gameObject.SetActive(true);
        guiGameOver.HideGUI();
        score = 0;
        Time.timeScale = 1;
        pauseResumeController.Hide();
    }

    private void Update()
    {
        scoreCounter.SetScore(score);
        //countTimer -= Time.unscaledDeltaTime;
    }

    public void PauseGame()
    {
        gameState = GameState.Paused;
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        gameState = GameState.Started;
        Time.timeScale = 1;
    }

    public void AddScore()
    {
        if (gameState != GameState.Started) return;
        SoundManager.PlaySound("point");
        score++;
    }

    public void StartGame()
    {
        gameState = GameState.Started;
        guiPrepare.SetActive(false);
        pauseResumeController.Show();

        obstacleSpawner.StartSpawn();
        player.StartMoving();
    }

    public void GameOver()
    {
        if (gameState != GameState.Started) return;
        obstacleSpawner.StopSpawn();
        gameState = GameState.Ended;

        scoreCounter.gameObject.SetActive(false);
        UpdateGameHighScore();
        guiGameOver.SetScore(score, PlayerPrefs.GetInt("HighScore"));
        guiGameOver.ShowGUI();
        pauseResumeController.Hide();
    }

    private void UpdateGameHighScore()
    {
        int oldHighScore = 0;
        if (PlayerPrefs.HasKey("HighScore"))
        {
            oldHighScore = PlayerPrefs.GetInt("HighScore");
        }

        if (score > oldHighScore || oldHighScore == 0)
        {
            PlayerPrefs.SetInt("HighScore", score);
        }
    }

    public void RestartGame()
    {
        SoundManager.PlaySound("swooshing");
        SceneManager.LoadScene("GameScene");
    }

    public void BackToMenu()
    {
        SoundManager.PlaySound("swooshing");
        SceneManager.LoadScene("MenuScene");
    }
}