using UnityEngine;

public class BulletController : MonoBehaviour
{
    public int damage = 15;
   


    void OnCollisionEnter(Collision collision)
    {
        EnemyHealth enemyHealth = collision.gameObject.GetComponent<EnemyHealth>();
        if (enemyHealth != null)
        {
            enemyHealth.TakeDamage(damage);
        }
        Destroy(gameObject); // Destroy the bullet after hitting
    }
}
