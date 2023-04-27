using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class RoadScroller : MonoBehaviour
{
    public GameObject RoadPrefab;
    public BoxCollider2D collider;
    public Rigidbody2D rb;
    public float scrollSpeed = -10f;
    private float height;
    
    
    // Start is called before the first frame update
    void Start()
    {

        collider = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();

        height = collider.size.y;
        collider.enabled = false;

        rb.velocity = new Vector2(0, scrollSpeed);
        

    }

    // Update is called once per frame

    void Update()
    {
        if (transform.position.y < -height)
        {
            
            Vector2 resetPosition = new Vector2(0, height);
            transform.position = (Vector2)transform.position + resetPosition;
            Instantiate(RoadPrefab, resetPosition, Quaternion.identity);
            Destroy(gameObject);
            
        }
    }


    
    }


