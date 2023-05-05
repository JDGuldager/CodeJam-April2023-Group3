using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bed_script : MonoBehaviour
{
    Rigidbody2D rb;
    float dx;
    float dy;
    // bool IsPandaSpawned = false; //Check if the panda is there, so only one at a time
    private float min_x = -1.55f, max_x = 1.55f;

    [SerializeField] float moveSpeed = 10f;

    //[SerializeField] GameObject PandaPreFab; //Panda object

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //SpawnPanda(); //Its starts with a panda already on the screen
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
        rb.velocity = new Vector2(dx, dy);
    }

   
}
