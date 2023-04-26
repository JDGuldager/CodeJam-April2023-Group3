using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panda_script : MonoBehaviour
{
    
    private Rigidbody2D rb;
    float speed = 50f;

    void Start()
    {

        rb = GetComponent<Rigidbody2D>();   
    }

    void FixedUpdate()
    {
        rb.transform.position = new Vector3(Random.Range(0,10), -50, Random.Range(0,10)) * speed;
    }
}
