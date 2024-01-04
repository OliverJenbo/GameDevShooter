using UnityEngine;

public class BulletController : MonoBehaviour
{
    



    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Assuming player has a PlayerHealth component
            int damage = 10; // Determine the damage value
            collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(damage);
        }
        else if (collision.gameObject.CompareTag("Enemy"))
        {
            // Assuming enemies have an EnemyHealth component
            int damage = 15; // Determine the damage value
            collision.gameObject.GetComponent<EnemyHealth>().TakeDamage(damage);
        }

        // Destroy the bullet after hitting something
        Destroy(gameObject);
    }

}
