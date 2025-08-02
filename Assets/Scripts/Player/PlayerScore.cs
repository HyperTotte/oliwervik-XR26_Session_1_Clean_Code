using System;
using UnityEngine;


public class PlayerScore : MonoBehaviour, ICollisionHandler
{
    public event Action OnWin;
    public event Action<float> OnScoring;
    private float score = 0f;
    public float Score => score;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    

    public void HandleCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Collectible"))
        {
            GainScore(10f);
            Destroy(collision.gameObject);
        }
    }

    public void HandleTriggerEnter(Collider other)
    {

    }

    private void GainScore(float amount)
    {
        score += amount;
        //UpdateScoreUI();
        OnScoring?.Invoke(score);
        Debug.Log("Collected! Score: " + score);

        if(score >= 30)
        {
            OnWin?.Invoke();
            Debug.Log("Player have won");
        }
    }

}
