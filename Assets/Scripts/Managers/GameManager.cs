using UnityEngine;
using TMPro;
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
        DontDestroyOnLoad(gameObject); // prepare if I/we want to add scenes.
    }

    // Game state variables
    public bool gameOver = false;
    public float gameTime = 0f;

    // UI elements directly managed by GameManager (tight coupling)
    [SerializeField]
    private TextMeshProUGUI gameStatusText;
    [SerializeField]
    private TextMeshProUGUI timerText;
    [SerializeField]
    private GameObject gameOverPanel; 

    // Tightly coupled dependency to Player (violating Separation of Concerns)
    [SerializeField]
    private Player player;

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
             * it was that playerhealth was on gamemanager and not player.
             * fix: attacth playerhealth on player. in gamemanager, s.field "playerhealth" attacth player (object).
             */
        }
        // Initialize UI
        if (gameStatusText != null)
        {
            gameStatusText.text = "Game Started!";
        }
        if (player == null)
        {
            player = FindFirstObjectByType<Player>();
            if (player == null)
            {
                Debug.LogError("GameManager cannot find Player script!");
            }
        }
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false);
        }
        Debug.Log("GameManager initialized.");
    }

    void Update()
    {
        if (!gameOver)
        {
            gameTime += Time.deltaTime;
            UpdateTimerUI();

            // Win condition (tightly coupled)
            //if (player.GetScore() >= 30) // Direct access to player score
            //{
            //    WinGame();
            //}
        }
    }

    private void UpdateTimerUI()
    {
        if (timerText != null)
        {
            timerText.text = "Time: " + Mathf.FloorToInt(gameTime).ToString() + "s";
        }
    }

    public void GameOver()
    {
        Debug.Log("starting Game over ()");
        if (!gameOver)
        {
            gameOver = true;
            Debug.Log("Game Over!");
            if (gameStatusText != null)
            {
                gameStatusText.text = "GAME OVER!";
            }
            if (gameOverPanel != null)
            {
                gameOverPanel.SetActive(true);
            }

            Invoke(nameof(RestartGame), 2f); // Restart after 2 seconds
        }
    }

    public void WinGame()
    {
        if (!gameOver) // Ensure win can only happen once
        {
            gameOver = true;
            //Debug.Log("You Win! Score: " + player.GetScore()); // Direct access to player score
            if (gameStatusText != null)
            {
                //gameStatusText.text = "YOU WIN! Score: " + player.GetScore();
            }

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