using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StackItBox : MonoBehaviour
{
    private float min_x = -1.4f, max_x = 1.4f;

    // private bool canMove;
    [SerializeField]private float moveSpeed = 2f;
    private Rigidbody2D myBody;

    private bool gameOver;
    private bool ignoreCollision;
    private bool ignoreTrigger;
    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();

        // REMOVE LATER???
       // myBody.gravityScale = 0f;
    }
    private void Update()
    {
        MoveBox();
    }
    private void Start()
    {
       // canMove = true;
        // Left or right spawn ( Will need to remove later ) 
        if (Random.Range(0, 2) > 0)
        {
            moveSpeed *= -2f;
        }
        // Create a reference to the box when it gets spawned
        StackItController.Instance.currentBox = this;
    }
    void MoveBox()
    {
      //  if(canMove)
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

        //TEST
        // creates joint
        FixedJoint2D joint = gameObject.AddComponent<FixedJoint2D>();
        // sets joint position to point of contact
        joint.anchor = target.contacts[0].point;
        // conects the joint to the other object
        joint.connectedBody = target.contacts[0].otherCollider.transform.GetComponentInParent<Rigidbody2D>();
        // Stops objects from continuing to collide and creating more joints
        joint.enableCollision = false;

        if (target.gameObject.tag == "Platform")
        {
            Invoke("Landed", .5f);
            ignoreCollision = true; 
            
        }
        if (target.gameObject.tag == "Box")
        {
            Invoke("Landed", .5f);
            ignoreCollision |= true;
           
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

}
