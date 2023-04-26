using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stork_script : MonoBehaviour
{
    [SerializeField] float speed = 300f; //The speed
    [SerializeField] Rigidbody2D rbStork;
    public float respawn = -250f;

    // public GameObject BabyPanda;
    // public int numPanda = 10;
    // public int minX = -200;
    // public int maxX = 200;
    // public int y = -250;

    void Start()
    {
        rbStork = GetComponent<Rigidbody2D>();
        rbStork.velocity = new Vector2(-speed, 0f); //The stork moves from left to right

        //Panda spawning
        // for (int i = 0; i < numPanda; i++){
        //     float x = Random.Range(minX, maxX);
        //     Instantiate(BabyPanda, new Vector3(x, y, 0f), Quaternion.Euler(0f, 0f, 0f));
        //     Debug.Log(BabyPanda.transform.position);
        // }

    }


    void FixedUpdate()
    {
        if(respawn > rbStork.transform.position.x){
            Vector2 newPos = new Vector2(respawn + 1400f, rbStork.transform.position.y); 
            //You can also do it like this to not have magic number "Camera.main.aspect * Camera.main.orthographicSize * 2f"
            rbStork.transform.position = newPos;
        }
        //rbPanda.transform.position = new Vector3(Random.Range(0,10), -50, Random.Range(0,10)) * speed;

    }
}
