using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SensorController : MonoBehaviour
{
    Rigidbody2D rb;
    float dx;
    float dy;

    public static float moveSpeed = 20f;
    public static float startMoveSpeed = 20f;

    float yMin = -4.5f; // Variable replacing MN.
    float yMax = 4.5f; // Variable replacing MN.

    float xMin = -2.5f; // Variable replacing MN.
    float xMax = 2.5f; // Variable replacing MN.

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        dx = Input.acceleration.x * moveSpeed;
        float yPosition = Mathf.Clamp(transform.position.y, yMin, yMax); // Replacement of MN.
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, xMin, xMax), yPosition); // Replacement of MN.

        dy = Input.acceleration.y * moveSpeed;
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(dx, dy);
    }
}
