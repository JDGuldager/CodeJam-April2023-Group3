using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stork_script : MonoBehaviour
{
    [SerializeField] float speed = 5f; //The speed
    private Rigidbody2D rb;

    public float respawn = -250f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(-speed, 0f); //The stork moves from left to right
    }


    void Update()
    {
        if(respawn > transform.position.x){
            Vector2 newPos = new Vector2(respawn + 1400f, transform.position.y); 
            //You can also do it like this to not have magic number "Camera.main.aspect * Camera.main.orthographicSize * 2f"
            transform.position = newPos;
        }


    }
}
