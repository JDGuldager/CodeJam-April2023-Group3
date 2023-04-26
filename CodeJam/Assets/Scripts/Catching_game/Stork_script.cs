using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stork_script : MonoBehaviour
{
    [SerializeField] float speed = 5f; //The speed
    [SerializeField] Rigidbody2D rbStork;
    [SerializeField] Rigidbody2D rbPanda;

    public float respawn = -250f;

    void Start()
    {
        rbStork = GetComponent<Rigidbody2D>();
        rbPanda = GetComponent<Rigidbody2D>();
        rbStork.velocity = new Vector2(-speed, 0f); //The stork moves from left to right
    }


    void FixedUpdate()
    {
        if(respawn > transform.position.x){
            Vector2 newPos = new Vector2(respawn + 1400f, transform.position.y); 
            //You can also do it like this to not have magic number "Camera.main.aspect * Camera.main.orthographicSize * 2f"
            transform.position = newPos;
        }
    rbPanda.transform.position = new Vector3(Random.Range(0,10), -50, Random.Range(0,10)) * speed;

    }
}
