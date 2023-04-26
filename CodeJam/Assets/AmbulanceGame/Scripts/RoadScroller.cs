using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;

public class RoadScroller : MonoBehaviour
{
    public BoxCollider2D collider;

    public Rigidbody2D rb;

    private float height;

    public float scrollSpeed = -2f;
    // Start is called before the first frame update
    void Start()
    {
        
        collider = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();

        height = collider.size.y;
        collider.enabled = false;

        rb.velocity = new Vector2(0, scrollSpeed);
        ResetObstacle();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -height)
        {
            Vector2 resetPosition = new Vector2( 0,height * 2f );
            transform.position = (Vector2)transform.position + resetPosition;
        }
    }

    void ResetObstacle()
    {
        transform.GetChild(0).localPosition = new Vector3(2, Random.Range(1, 11), 0);
    }
}
