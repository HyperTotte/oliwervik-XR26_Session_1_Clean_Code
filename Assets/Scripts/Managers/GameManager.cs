using JetBrains.Annotations;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour // start of singelton
{
    public static GameManager Instance { get; private set; }

    [SerializeField] private PlayerHealth playerHealth;
    [SerializeField] private PlayerScore playerScore;
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject); // makes sure only one inst.
            return;
        }

        Instance = this;
        // DontDestroyOnLoad(gameObject); // prepared if I/we want to add scenes.    disable because of the restart logic 
    }

    public event Action<float> OnTimeChanged;

    // Game state variables
    public bool gameOver = false;
    private float gameTime = 0f;
    
    private void Start()
    {
        

        if (playerScore != null)
        {
            playerScore.OnWin += WinGame;
            Debug.Log("Subscribed to PlayerScore.OnWin");
        }

        if (playerHealth != null)
        {
            playerHealth.OnDeath += GameOver;
            Debug.Log("subscribed to playerHealth.OnDeatth");
        }
        else
        {
            Debug.LogError("playerHealth referance missing in gamemanager");
            /*
             * had problem where the GameOver() would not be called. 
             * it was that playerhealth was on gamemanager and not player, thought that script was gonna go in s.field but it would'nt take that.
             * fix: attacth playerhealth on player. in gamemanager, s.field "playerhealth" attacth player (object).
             */
        }        
    }

    void Update()
    {
        if (!gameOver)
        {
            gameTime += Time.deltaTime;
            OnTimeChanged?.Invoke(gameTime);
        }
    }

    

    public void GameOver()
    {
        Debug.Log("starting Game over ()");
        if (!gameOver)
        {
            gameOver = true;
            Debug.Log("Game Over!");
            Invoke(nameof(RestartGame), 2f); // Restart after 2 seconds
        }
    }

    public void WinGame()
    {
        if (!gameOver) // Ensure win can only happen once
        {
            gameOver = true;
            Invoke(nameof(RestartGame), 2f); // Restart after 2 seconds
        }
    }

    public void RestartGame()
    {
        Debug.Log("Restarting Game...");
        Time.timeScale = 1f; // Resume game
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reload current scene
    }
}