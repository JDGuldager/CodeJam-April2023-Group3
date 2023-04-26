using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class StackItBox : MonoBehaviour
{
    // 1.8
    private float min_x = -1.8f, max_x = 1.8f;

    // private bool canMove;
    [SerializeField]private float moveSpeed = 2f;
    private Rigidbody2D myBody;
    private RelativeJoint2D myJoint;
    public GameObject boxObj;
    public GameObject platformObj;
    private bool gameOver;
    private bool ignoreCollision;
    private bool ignoreTrigger;
    private bool canMove;
    private bool platformHit;
    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();

        // REMOVE LATER???
      //  myBody.gravityScale = 0f;
    }
    private void Update()
    {
        MoveBox();
        if (platformHit == true)
        {
            boxObj.transform.position = platformObj.transform.position + platformObj.transform.TransformDirection(new Vector3(0, 0.5f, -1));
        }
    }
    private void Start()
    {
        boxObj = gameObject;
        platformHit = false;
        canMove = true;
        // Left or right spawn ( Will need to remove later ) 
        if (Random.Range(0, 2) > 0)
        {
            moveSpeed *= -1.6f;
        }
        // Create a reference to the box when it gets spawned
        StackItController.Instance.currentBox = this;
    }
    void MoveBox()
    {
        if(canMove)
        {
            Vector3 temp = transform.position;
            temp.x += moveSpeed * Time.deltaTime;
            if(temp.x > max_x)
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
    public void DropBox()
    {
      //  canMove = false;
        myBody.gravityScale = Random.Range(2, 4);
    }
    void Landed()
    {
        if (gameOver) return;
        ignoreCollision = true;
        Invoke("IgnoreTriggerDelay", 2f);
        StackItController.Instance.SpawnNewBox();
        StackItController.Instance.MoveCamera();
    }
    void RestartGame()
    {
        StackItController.Instance.RestartGame();
    }
    private void OnCollisionEnter2D(Collision2D target)
    {
        if (ignoreCollision == true) return;

        // MAYBE USE??

        // var joint = gameObject.AddComponent<FixedJoint2D>();
        // joint.connectedBody = target.rigidbody;
        // joint.enableCollision = false;

        var hj = gameObject.AddComponent<HingeJoint2D>();
        hj.connectedBody = target.rigidbody;
        myBody.mass = 0.00001f;
       
        myBody.freezeRotation = true;
        myBody.velocity = new Vector3(0, 0,0);
        moveSpeed = 0;

        if (target.gameObject.tag == "Platform")
        {
            platformObj = target.gameObject;
            platformHit = true;
            Invoke("Landed", .5f);
            ignoreCollision = true;
            canMove = false;
            Invoke("Stick", 2f);
        }
        if (target.gameObject.tag == "Box")
        {
            Invoke("Landed", .5f);
            ignoreCollision |= true;
            canMove = false;
            Invoke("Stick", 2f);
        }
    }
    private void OnTriggerEnter2D(Collider2D target)
    {
        if(ignoreTrigger == true) return;
        if(target.gameObject.tag == "GameOver")
        {
            CancelInvoke("Landed");
            gameOver = true;
            ignoreTrigger = true;
            Invoke("RestartGame", 1f);
        }
    }
    // Delay the ignore collision is the box simply touches the top box
    void IgnoreTriggerDelay()
    {
        ignoreTrigger = true;
    }
    void Stick()
    {
        //  myJoint = GetComponent<RelativeJoint2D>();
        myBody.freezeRotation = true;
    }

}
