using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, ICollisionHandler
{
    public event Action OnDeath;
    [SerializeField] private float maxHealth = 30f;
    private float currentHealth;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        currentHealth = maxHealth;
    }
    public void HandleCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(10);
        }
    }

    public void HandleTriggerEnter(Collider other)
    {
        // required but not used.
    }

    private void TakeDamage(float amount)
    {
        currentHealth -= amount;
        Debug.Log("Player took dmg");

        if (currentHealth <= 0f)
        {
            OnDeath?.Invoke();
            Debug.Log("Player has died");
        }
    }


}
