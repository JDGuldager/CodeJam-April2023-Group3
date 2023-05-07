using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackItSensor : MonoBehaviour
{
    Rigidbody2D rb;
    float dx;
    float dy;
    public float min_x = -1.55f, max_x = 1.55f;
    [SerializeField]
    float moveSpeed = 20f;
    float ADsteer;
    [SerializeField]
    float steerSpeed = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        ADSteer();
        // SensorSteer();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(dx, dy);
    }

    // Our singleton
    void SensorSteer()
    {
        dx = Input.acceleration.x * moveSpeed;
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, min_x, max_x), transform.position.y);

        dy = Input.acceleration.y * moveSpeed;
    }
    // This function is for debugging so I wont have to build to a phone
    void ADSteer()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            ADsteer = -steerSpeed;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            ADsteer = steerSpeed;
        }
        dx = ADsteer * moveSpeed;
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, min_x, max_x), transform.position.y);

        dy = ADsteer * moveSpeed;
    }
}
