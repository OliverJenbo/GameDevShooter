using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform barrelEnd; // The end of the gun barrel
    public Camera playerCamera; // Reference to the player's camera
    public float bulletSpeed = 30.0f; // Set the speed of the bullet


    void Update()
    {
        if (Input.GetButtonDown("Fire1")) // Change "Fire1" to your desired input control
        {
            Shoot();
        }
    }

    public void Shoot()
    {
        // Instantiate the bullet at the end of the barrel
        GameObject bullet = Instantiate(bulletPrefab, barrelEnd.position, playerCamera.transform.rotation);

        // Set the bullet's velocity in the camera's forward direction
        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
        bulletRb.velocity = playerCamera.transform.forward * bulletSpeed;
    }
}



   

   
