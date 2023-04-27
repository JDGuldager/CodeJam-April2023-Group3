using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 10.0f;
    public float lifetime = 5.0f;
    public GameObject BacteriaPrefab; 

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

   private void OnTriggerEnter2D(Collider2D collision) {
        Destroy(gameObject);
        Destroy(collision.gameObject);

   }

}
