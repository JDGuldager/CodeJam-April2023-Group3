using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bed_script : MonoBehaviour
{
    Rigidbody2D rb;
    float dx;
    float dy;
   // bool IsPandaSpawned = false; //Check if the panda is there, so only one at a time

    [SerializeField] float moveSpeed = 20f;

    //[SerializeField] GameObject PandaPreFab; //Panda object

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //SpawnPanda(); //Its starts with a panda already on the screen
    }

    // Update is called once per frame
    void Update()
    {
        dx = Input.acceleration.x * moveSpeed;
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, -Screen.width / 2f + 0.5f, Screen.width / 2f - 0.5f), transform.position.y);


    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(dx, 0f);
    }

    // private void SpawnPanda(){
    //     if (IsPandaSpawned == false){
    //         Vector3 PanPosition = new Vector3(Random.Range(-2, 2), 800f, 0f); //Makes the panda spawn on a random range on x axis 
    //         Instantiate(PandaPreFab, PanPosition, Quaternion.identity); //Instantiate the prefab at the random loc
    //         IsPandaSpawned = true;
    //     }
    // }

   
}
