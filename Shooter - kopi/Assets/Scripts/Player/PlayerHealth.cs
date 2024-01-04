using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public PlayerHealthBar playerHealthBar;
    public int maxHealth = 100;
    private int currentHealth;


    void Start()
    {
        currentHealth = maxHealth; 
        playerHealthBar.SetMaxHealth(maxHealth);
    }
   

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        playerHealthBar.SetHealth(currentHealth);
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        RestartLevel();
    }
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
