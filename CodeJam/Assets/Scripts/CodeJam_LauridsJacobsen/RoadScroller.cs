using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;
//Makes the road loop to create an endless road. inspired by this youtube video https://www.youtube.com/watch?v=4YQVrs46f6k
//Attached to the road prefabs
public class RoadScroller : MonoBehaviour
{
    public GameObject roadPrefab;
    public BoxCollider2D collider;
    public Rigidbody2D rb;
    public float scrollSpeed = -10f;
    private float height;
    public GameObject hospitalPrefab;
    public ObstacleSpawner obstacleSpawnScript;
    private bool hospitalSpawned = false;
    
    void Start()
    {
        obstacleSpawnScript = GameObject.Find("ObstacleSpawner").GetComponent<ObstacleSpawner>();
        collider = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        height = collider.size.y;
        collider.enabled = false;
        
    }
    
    void Update()
    //Destroys the road prefab and instantiates a new as long as less than repeatMax obstacles have been spawned
    {   
        if (transform.position.y < -height && obstacleSpawnScript.repeatCounter < obstacleSpawnScript.repeatMax)
        {
            Vector2 resetPosition = new Vector2(0, height);
            transform.position = (Vector2)transform.position + resetPosition;
            Instantiate(roadPrefab, resetPosition, Quaternion.identity);
            Destroy(gameObject);
        }
        else if (obstacleSpawnScript.repeatCounter >= obstacleSpawnScript.repeatMax)
        {
            rb.velocity = new Vector2(0, scrollSpeed);
        }
        rb.velocity = new Vector2(0, scrollSpeed);
    }

    private void FixedUpdate()
    {
        //if repeatMax obstacles have spawned, instantiates the hospital prefab to complete the game
        if (obstacleSpawnScript.repeatCounter == obstacleSpawnScript.repeatMax && hospitalSpawned == false)
        {
            hospitalSpawned = true; //true/false statement to make sure it only spawns once
            Vector2 resetPosition = new Vector2(0, height);
            transform.position = (Vector2)transform.position + resetPosition;
            Instantiate(hospitalPrefab, resetPosition, Quaternion.identity);
        }
    }

}
