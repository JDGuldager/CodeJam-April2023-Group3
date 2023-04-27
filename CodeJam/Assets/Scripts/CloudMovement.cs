using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This script handles the Cloud movement, speed, direction, and the destuction of the Cloud if they exit the play area
 */

public class CloudMovement : MonoBehaviour
{
    public Vector2 speed;       
    public Sprite[] sprites;    //Sprites in array
    public bool moveLeft;       //Move dir
    private float finalSpeed;   //A random speed between the min and max
    private Rigidbody2D rb;     //Rigidbody
    private int x;              //Is either 1 or -1. Used in rb.velocity to decide which dir to move

    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        //Sets the sprite to and random sprite from the sprite array
        GetComponent<SpriteRenderer>().sprite = sprites[Random.Range(0, sprites.Length)]; 

        //Flips the Cloud sprite if necessary
        FlipCloud(); 

        //Decides the random speed between min and max
        finalSpeed = Random.Range(speed.x, speed.y); 
    }

    public void FixedUpdate()
    {
        Move(x);
    }

    public void Move(float dir)
    {
        // Moves the Rigidbody
        rb.velocity = dir * transform.right * finalSpeed * Time.deltaTime;
    }

    public void FlipCloud()
    {
        //Checks if the Cloud needs to be flipped.
        if (!moveLeft)
        {
            x = 1;

            //Flips the Cloud
            transform.localScale = new Vector3(-x, 1, 1);
        }
        else x = -1;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // If the Cloud comes in contact with the destroy boundry, Cloud is destroyed
        if (other.CompareTag("Destroy"))
        {
            Destroy(gameObject);
        }
    }
}
