using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public Healthbar healthBar;
    public int maxHealth = 100;
    private int currentHealth;
    

    void Start()
    {
        currentHealth = maxHealth; // Initialize health when the enemy is spawned
        healthBar.SetMaxHealth(maxHealth);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        // Add death logic here (e.g., play animation, remove enemy, etc.)
        Destroy(gameObject); // Destroy enemy object
    }
}
