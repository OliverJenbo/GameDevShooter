using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform barrelEnd;
    public float bulletSpeed = 30.0f;
    public float fireRate = 1f;
    public float nextFireTime = 0f;

    // Call this method to make the enemy shoot
    public void ShootAtPlayer(Transform playerTarget)
    {
        if (Time.time >= nextFireTime)
        {
            Vector3 shootDirection = (playerTarget.position - transform.position).normalized;
            FireBullet(shootDirection);
            nextFireTime = Time.time + 1f / fireRate;
        }
    }

    private void FireBullet(Vector3 direction)
    {
        GameObject bullet = Instantiate(bulletPrefab, barrelEnd.position, Quaternion.LookRotation(direction));
        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
        bulletRb.velocity = direction * bulletSpeed;
    }
}