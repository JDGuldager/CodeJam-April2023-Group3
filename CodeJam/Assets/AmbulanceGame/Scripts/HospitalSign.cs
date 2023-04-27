using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HospitalSign : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D col;

    void Start()
    {
        col = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, -10);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Timer.NextScene();
        }
    }
}
