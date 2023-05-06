using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickerShooter : MonoBehaviour
{
    public GameObject projectilePrefab;
    public float fireRate = 1.0f;

    private float nextFireTime = 0.0f;

    public AudioClip sound;

    void Update()
    {
        // Check if the user has touched the screen, through touchCount
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began || Input.GetMouseButtonDown(0)) /*GetMouseButtonDown is to test if it works on a computer*/
        {
            // Check if enough time has passed since the last shot
            if (Time.time > nextFireTime)
            {
                // Fire a projectile
                GameObject projectile = Instantiate(projectilePrefab, transform.position, transform.rotation);
                nextFireTime = Time.time + fireRate;
                SoundManager.instance.PlaySound(sound);
            }
        }
    }
}