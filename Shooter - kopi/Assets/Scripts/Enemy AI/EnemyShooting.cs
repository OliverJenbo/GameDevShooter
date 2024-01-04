using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public WeaponController weaponController;
    public float fireRate = 1f;
    public float nextFireTime = 0f;

    void Start()
    {
        if (weaponController == null)
        {
            weaponController = GetComponent<WeaponController>();
            if (weaponController == null)
            {
                Debug.LogError("WeaponController component not found on the enemy");
            }
        }
    }

    public void ShootAtPlayer(Transform playerTarget)
    {
        if (Time.time >= nextFireTime)
        {
            weaponController.EnemyShoot(); // Utilize WeaponController's method
            nextFireTime = Time.time + 1f / fireRate;
        }
    }
}