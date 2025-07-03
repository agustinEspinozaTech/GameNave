using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class UIManagerSingleton : MonoBehaviour
{
    public static UIManagerSingleton instance;

    [SerializeField] private TextMeshProUGUI livesText;
    [SerializeField] private TextMeshProUGUI timeText;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject victoryPanel;
    private int currentLives;
    private float elapsedTime = 0f;


    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    [SerializeField] private TextMeshProUGUI killsText;
    [SerializeField] private TextMeshProUGUI scoreText;

    private int currentKills = 0;
    private int currentScore = 0;


    public void UpdateKills()
    {
        currentKills++;
        killsText.text = "Kills: " + currentKills;
    }

    public void UpdateScore(int addScore)
    {
        currentScore += addScore;
        scoreText.text = "Score: " + currentScore;
    }

    public void SetLives(int lives)
    {
        currentLives = Mathf.Max(0, lives);
        livesText.text = "Lives: " + currentLives;

    }
    public void ShowGameOver()
    {
        if (gameOverPanel != null)
            gameOverPanel.SetActive(true);
    }
    public void UpdateTimer()
    {
        elapsedTime += Time.deltaTime;
        int minutes = Mathf.FloorToInt(elapsedTime / 60f);
        int seconds = Mathf.FloorToInt(elapsedTime % 60f);
        timeText.text = $"Time: {minutes:00}:{seconds:00}";
    }
    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void ShowVictory()
    {
        if (victoryPanel != null)
            victoryPanel.SetActive(true);
    }

}