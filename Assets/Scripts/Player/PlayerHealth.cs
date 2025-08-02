using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, ICollisionHandler
{
    public event Action OnDeath;
    public event Action<float> OnDamageTaken;
    [SerializeField] private float maxHealth = 30f;
    private float currentHealth;

    public float MaxHealth => maxHealth;
    public float CurrentHealth => currentHealth;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        currentHealth = maxHealth;
        OnDamageTaken?.Invoke(currentHealth);
    }
    public void HandleCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(10);
            Destroy(collision.gameObject);
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
        OnDamageTaken?.Invoke(currentHealth);
        if (currentHealth <= 0f)
        {
            OnDeath?.Invoke();
            Debug.Log("Player has died");
        }
    }


}
