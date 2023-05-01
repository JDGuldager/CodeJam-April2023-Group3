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
    public GameObject hospitalPrefab;
    public ObstacleSpawner obstacleSpawnScript;
    private bool hospitalSpawned = true;
//https://www.youtube.com/watch?v=4YQVrs46f6k INSPIRATION

    // Start is called before the first frame update
    void Start()
    {
        obstacleSpawnScript = GameObject.Find("ObstacleSpawner").GetComponent<ObstacleSpawner>();

        collider = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();

        height = collider.size.y;
        collider.enabled = false;

        rb.velocity = new Vector2(0, scrollSpeed);


    }

    // Update is called once per frame

    void Update()
    {
        if (transform.position.y < -height && obstacleSpawnScript.repeatCounter < 20)
        {

            Vector2 resetPosition = new Vector2(0, height);
            transform.position = (Vector2)transform.position + resetPosition;
            Instantiate(RoadPrefab, resetPosition, Quaternion.identity);
            Destroy(gameObject);
        }
        

    }

    private void FixedUpdate()
    {
        if (obstacleSpawnScript.repeatCounter == 20 && hospitalSpawned)
        {
            hospitalSpawned = false;
            Vector2 resetPosition = new Vector2(0, height);
            transform.position = (Vector2)transform.position + resetPosition;
            Instantiate(hospitalPrefab, resetPosition, Quaternion.identity);
        }
    }

}
