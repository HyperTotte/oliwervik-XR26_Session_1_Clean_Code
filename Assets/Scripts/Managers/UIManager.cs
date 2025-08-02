using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
using UnityEngine.SocialPlatforms.Impl;
public class UIManager : MonoBehaviour
{
    [Header("Listeners")]
    [SerializeField] private PlayerHealth playerHealth;
    [SerializeField] private PlayerScore playerScore;
    [SerializeField] private GameManager gameManager;
    [Header("UI")]
    [SerializeField]
    private TextMeshProUGUI scoreText;
    [SerializeField]
    private Slider healthBar;
    [SerializeField]
    private TextMeshProUGUI gameStatusText;
    [SerializeField]
    private TextMeshProUGUI timerText;
    [SerializeField]
    private GameObject gameOverPanel;

    private float maxHealth;
    private float currentHealth;
    private float score;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        maxHealth = playerHealth.MaxHealth;
        currentHealth = playerHealth.CurrentHealth;
        score = playerScore.Score;
        
        
        if (healthBar != null)
        {
            healthBar.maxValue = maxHealth; // Set to match max health value
            healthBar.value = currentHealth; // Ensure current value matches
        }

        if (playerScore != null)
        {
            playerScore.OnScoring += UpdateScoreUI;
            Debug.Log("Subscribed to PlayerScore.OnWin");
        }

        if (playerHealth != null)
        {
            playerHealth.OnDamageTaken += UpdateHealthUI;
            Debug.Log("subscribed to playerHealth.OnDeatth");
        }

        if (gameManager != null)
        {
            gameManager.OnTimeChanged += UpdateTimerUI;
            Debug.Log("subscribed to gameManager.OnTimeChanged");
        }

        if (gameStatusText != null)
        {
            gameStatusText.text = "Game Started!";
        }
        
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false);
        }
        Debug.Log("UIManager initialized.");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void UpdateTimerUI(float gameTime)
    {
        if (timerText != null)
        {
            timerText.text = "Time: " + Convert.ToInt32(gameTime) + "s";
        }
    }
    private void UpdateScoreUI(float score)
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
            if (score >= 30f)
            {
                gameStatusText.text = "YOU WIN! Score: " + score;
                Debug.Log("You Win! Score: " + score);
            }
        }
    }
    private void UpdateHealthUI(float currentHealth)
    {
        if (healthBar != null)
        {
            healthBar.value = currentHealth;
            Debug.Log("dmg UI");
            if (healthBar.value <= 0f)
            {
                if (gameStatusText != null)
                {
                    gameStatusText.text = "GAME OVER!";

                }
                if (gameOverPanel != null)
                {
                    gameOverPanel.SetActive(true);
                }
            }
        }
    }
}
