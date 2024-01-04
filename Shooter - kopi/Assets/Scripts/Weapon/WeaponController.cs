using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform barrelEnd;
    public float bulletSpeed = 30.0f;
    public AudioClip gunshotSound; // Assign this in the inspector

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayerShoot()
    {
        Shoot(Camera.main.transform.forward);
        PlayGunshotSound();
    }

    public void EnemyShoot()
    {
        Shoot(transform.forward);
        PlayGunshotSound();

    }

    private void Shoot(Vector3 shootDirection)
    {
        GameObject bullet = Instantiate(bulletPrefab, barrelEnd.position, Quaternion.LookRotation(shootDirection));
        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
        bulletRb.velocity = shootDirection * bulletSpeed;
    }

    public void PlayGunshotSound()
    {
        if (audioSource != null && gunshotSound != null)
        {
            audioSource.PlayOneShot(gunshotSound);
        }
        else
        {
            Debug.LogError("AudioSource or gunshot sound is missing on the weapon");
        }
    }
}
