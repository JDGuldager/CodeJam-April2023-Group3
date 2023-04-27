using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Autoshooter : MonoBehaviour
{
    public GameObject projectilePrefab;
    public float fireRate = 1.0f;

    private float nextFireTime = 0.0f;

    void Update()
    {
        if (Time.time > nextFireTime)
        {
            GameObject projectile = Instantiate(projectilePrefab, transform.position, transform.rotation);
            nextFireTime = Time.time + fireRate;
            SoundManager.PlaySound(SoundManager.Sound.Waterdroplet);
        }
    }
}
