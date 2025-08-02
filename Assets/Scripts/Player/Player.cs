using UnityEngine;
using TMPro; // Assuming TextMeshPro is used for UI
using UnityEngine.UI;

public class Player : MonoBehaviour
{
 
   
    // Tightly coupled dependency to GameManager
    [SerializeField]
    private GameManager gameManager;

    // Direct UI references - bad practice for player script
    [SerializeField]
    private TextMeshProUGUI scoreText;
    [SerializeField]
    private Slider healthBar;

    void Start()
    {
        if (gameManager == null)
        {
            gameManager = FindFirstObjectByType<GameManager>();
            if (gameManager == null)
            {
                Debug.LogError("Player cannot find GameManager!");
            }
        }
        //UpdateScoreUI();
        //UpdateHealthUI();   add when fix UI
        
        // Initialize health bar max value
        //if (healthBar != null)
        //{
        //    healthBar.maxValue = 30f; // Set to match max health value
        //    healthBar.value = health; // Ensure current value matches
        //}  add later?
    }

    void Update()
    {
        


       
    }


    // Health management (Monolithic, includes UI logic)
    //public void TakeDamage(float amount)
    //{
    //    health -= amount;
    //    health = Mathf.Max(health, 0); // Health won't go below zero
    //    UpdateHealthUI();
    //}

    //private void UpdateScoreUI()
    //{
    //    if (scoreText != null)
    //    {
    //        scoreText.text = "Score: " + score;
    //    }
    //} 

    //private void UpdateHealthUI()
    //{
    //    if (healthBar != null)
    //    {
    //        healthBar.value = health;
    //    }
    //}

    //public int GetScore()
    //{
    //    return score;
    //}
}