using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Kilder:
//StackItSensors
public class SpaceInvadersMovement : MonoBehaviour
{
    Rigidbody2D rb;
    float dx;
    float dy;
    private float min_x = -2.22f, max_x = 2.22f;
    [SerializeField]
    float moveSpeed = 20f;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        dx = Input.acceleration.x * moveSpeed;
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, min_x, max_x), transform.position.y);

        dy = Input.acceleration.y * moveSpeed;
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(dx,0);
    }
}
