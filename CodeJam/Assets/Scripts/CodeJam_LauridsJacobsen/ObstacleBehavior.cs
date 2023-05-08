using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AdaptivePerformance.VisualScripting;
using UnityEngine.SceneManagement;

//Controls the speed and collision scenarios for obstacles
public class ObstacleBehavior : MonoBehaviour
{
    private Rigidbody2D rb;
    private float speed = -10f;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, speed);
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    //Either destroys obstacles out of screen or if colliding with player calls GameOver
    {
        if (other.gameObject.CompareTag("Destroyer"))
        {
            Destroy(gameObject);
        }
        else if (other.gameObject.CompareTag("Player"))
        {
            Timer.GameOver();
        }
    }
}