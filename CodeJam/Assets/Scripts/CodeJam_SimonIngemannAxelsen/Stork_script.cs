using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.SceneManagement;


public class Stork_script : MonoBehaviour
{
    [SerializeField] float speed; //The speed
    [SerializeField] public Rigidbody2D rbStork;
    [SerializeField] float respawn; 
    //The upper limit x location for the respawn
    public GameObject pandaPrefab;
    public Panda_script pandaScript;

    void Start()
    {
        rbStork = GetComponent<Rigidbody2D>();
        rbStork.velocity = new Vector2(-speed, 0f); //The stork moves from left to right
    }


    void FixedUpdate()
    {
        //The Camera.main.aspect * Camera.main.orthographicSize * 2f gives the width of the screen
        float screenWidth = Camera.main.aspect * Camera.main.orthographicSize * 2f;
        if (rbStork.transform.position.x < respawn) //If its position is over the screen limit spawn again 
        {
            //The position the stork should spawn
            Vector2 newPos = new Vector2(rbStork.transform.position.x + screenWidth, rbStork.transform.position.y);
            rbStork.transform.position = newPos; //Updates the storks position to
        }

    }
}
