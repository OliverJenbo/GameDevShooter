using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform barrelEnd;
    public float bulletSpeed = 30.0f;
    

    public void Shoot(Vector3 shootDirection)
    {
        GameObject bullet = Instantiate(bulletPrefab, barrelEnd.position, Quaternion.LookRotation(shootDirection));
        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
        bulletRb.velocity = shootDirection * bulletSpeed;
        Debug.Log("Bullet Velocity: " + bulletRb.velocity);
    }

    // This method is used by the player to shoot
    public void PlayerShoot()
    {
        Shoot(Camera.main.transform.forward); // Using the camera's forward direction
    }

    // This method can be used by enemies to shoot
    public void EnemyShoot()
    {
        Shoot(transform.forward); // Using the GameObject's forward direction
    }

    
}
