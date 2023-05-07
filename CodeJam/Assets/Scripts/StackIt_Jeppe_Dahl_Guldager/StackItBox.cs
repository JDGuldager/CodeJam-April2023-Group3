using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class StackItBox : MonoBehaviour
{
    private Rigidbody2D myBody;
    public GameObject boxObj;
    public GameObject platformObj;
    public BoxCollider2D myCollider;

    private bool gameOver;
    private bool ignoreCollision;
    private bool ignoreTrigger;
    private bool canMove;

    private float min_x = -1.8f, max_x = 1.8f;
    [SerializeField]
    private float moveSpeed = 2f;

    private void Awake()
    {
        platformObj = GameObject.Find("Platform");
        myBody = GetComponent<Rigidbody2D>();
        myCollider = GetComponent<BoxCollider2D>();
    }
    private void Start()
    {
        boxObj = gameObject;
        canMove = true;
        // Left or right spawn
        if (Random.Range(0, 2) > 0)
        {
            moveSpeed *= -moveSpeed;
        }
        // Create a reference to the box when it gets spawned
        StackItController.Instance.currentBox = this;
    }
    private void Update()
    {
        MoveBox();
    }

    void MoveBox()
    {
        if (canMove)
        {
            Vector3 temp = transform.position;
            temp.x += moveSpeed * Time.deltaTime;
            // What this if statement does is basically if the box
            // hits a border which is min_x or max_x it turns around
            if (temp.x > max_x)
            {
                moveSpeed *= -1f;
            }
            else if (temp.x < min_x)
            {
                moveSpeed *= -1f;
            }
            transform.position = temp;
        }
    }
    private void OnCollisionEnter2D(Collision2D target)
    {
        if (ignoreCollision == true) return;
        myBody.velocity = new Vector3(0, 0, 0);
        moveSpeed = 0;

        // Only sticks if the tag is "Box" and not "UsedBox" meaning it
        // can only stick to the top box
        if (target.gameObject.tag == "Box")
        {
            Invoke("Landed", .5f);
            ignoreCollision |= true;
            canMove = false;

            // Adds the joint that sticks the packs together
            var jointCreate = gameObject.AddComponent<HingeJoint2D>();
            jointCreate.connectedBody = target.rigidbody;

            // This was a BugFix, that fixed the sliding of the boxes.
            jointCreate.autoConfigureConnectedAnchor = false;
            
            target.gameObject.tag = "UsedBox";
        }
    }
    void Landed()
    {
        if (gameOver) return;
        ignoreCollision = true;
        Invoke("IgnoreTriggerDelay", 2f);
        // Call funtions from the Controller
        StackItController.Instance.SpawnNewBox();
        StackItController.Instance.MoveCamera();
    }

    // Delay the ignore collision is the box simply touches the top box
    void IgnoreTriggerDelay()
    {
        ignoreTrigger = true;
    }
  
    // Game Over
    private void OnTriggerEnter2D(Collider2D target)
    {
        if (ignoreTrigger == true) return;
        if (target.gameObject.tag == "GameOver")
        {
            CancelInvoke("Landed");
            gameOver = true;
            ignoreTrigger = true;
            Invoke("RestartGame", 1f);
        }
    }
    void RestartGame()
    {
        StackItController.Instance.GameOver();
    }
}
