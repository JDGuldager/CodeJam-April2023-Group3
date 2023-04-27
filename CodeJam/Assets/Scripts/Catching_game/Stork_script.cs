using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Stork_script : MonoBehaviour
{
    [SerializeField] float speed = 300f; //The speed
    [SerializeField] public Rigidbody2D rbStork;
    public float respawn = -2.5f;
    public GameObject pandaPrefab;
    public Panda_script pandaScript;
 
    public int numPanda = 1;
    public int minX = -2;
    public int maxX = 2;
    public int y = 0;
   // bool IsPandaSpawned = false;

   // [SerializeField] private TextMeshProUGUI tmp;
    public int score = 0;

    void Start()
    {
        //SpawnPanda();
        rbStork = GetComponent<Rigidbody2D>();
        rbStork.velocity = new Vector2(-speed, 0f); //The stork moves from left to right
        
    }


    void FixedUpdate()
    {
   
       // tmp.text = score.ToString();
        if (respawn > rbStork.transform.position.x)
        {
            Vector2 newPos = new Vector2(respawn + 4f, rbStork.transform.position.y);
            //You can also do it like this to not have magic number "Camera.main.aspect * Camera.main.orthographicSize * 2f"
            rbStork.transform.position = newPos;
        }

  
        //rbPanda.transform.position = new Vector3(Random.Range(0,10), -50, Random.Range(0,10)) * speed;

    }
}
