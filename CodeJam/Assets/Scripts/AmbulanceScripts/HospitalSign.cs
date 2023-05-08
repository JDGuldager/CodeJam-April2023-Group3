using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Handles the properties of the HospitalSign prefab and how the game is won
public class HospitalSign : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D col;
    private float scrollSpeed = -10f;
    [SerializeField] private float timeTillNext = 2f;

    void Start()
    {
        col = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, scrollSpeed);
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Timer.NextScene();
        }
    }
    
}
