using System;
using UnityEngine;


public class PlayerScore : MonoBehaviour, ICollisionHandler
{
    public event Action OnWin;
    private float score = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }



    // Update is called once per frame
    void Update()
    {
        
    }

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
        Debug.Log("Collected! Score: " + score);

        if(score >= 30)
        {
            OnWin?.Invoke();
            Debug.Log("Player have won");
        }
    }

}
