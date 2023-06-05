using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLightSensor: MonoBehaviour
{
    Rigidbody2D rb;
    float dx;
    float dy;

    [SerializeField]
    float moveSpeed = 20f;

    
    void Start()
    {
        //Gets the Rigidbody2D component attached 
        rb = GetComponent<Rigidbody2D>();
    }


    // accelaration values
    void Update()
    {
        
        dx = Input.acceleration.x * moveSpeed;

        // keeps the object between the values, so it doesn't go out of the bounds
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, -2.35f, 2.35f), transform.position.y);

        dy = Input.acceleration.y * moveSpeed;
    }

    private void FixedUpdate()
    {
        // velocity updated with the values of dx and dy 
        rb.velocity = new Vector2(dx, dy);
    }
}
