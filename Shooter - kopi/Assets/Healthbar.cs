using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    public Slider slider;
    public Transform camTransform;

    public void SetMaxHealth (int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    public void SetHealth(int health)
    {
        slider.value = health;
    }
    void LateUpdate()
    {
        if (camTransform == null)
        {
            camTransform = Camera.main.transform;
        }

        // Make the health bar face the camera. Only rotate on Y-axis if you want
        transform.LookAt(transform.position + camTransform.rotation * Vector3.forward,
                         camTransform.rotation * Vector3.up);
    }
}
