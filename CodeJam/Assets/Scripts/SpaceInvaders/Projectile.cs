using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 10.0f;
    public float lifetime = 5.0f;

    private float spawnTime;

    void Start()
    {
        spawnTime = Time.time;
    }

    void Update()
    {
        // Move the projectile in the forward direction.
        transform.Translate(Vector3.up * speed * Time.deltaTime);

        // Destroy the projectile after it has lived for the specified lifetime.
        if (Time.time - spawnTime >= lifetime)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if the projectile has collided with an enemy or other object and destroy it.
        if (other.CompareTag("Bacteria"))
        {
            Destroy(gameObject);
            // Do something to damage the enemy object here.
        }
        else
        {
            
        }
    }
}
