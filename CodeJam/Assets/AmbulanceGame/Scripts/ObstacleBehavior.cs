using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AdaptivePerformance.VisualScripting;
using UnityEngine.SceneManagement;


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
    {
        if (other.gameObject.CompareTag("Destroyer"))
            //if (other.gameObject.tag == "Destroyer")
        {
            Destroy(gameObject);
        }
        else if (other.gameObject.CompareTag("Player"))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }
    }
}