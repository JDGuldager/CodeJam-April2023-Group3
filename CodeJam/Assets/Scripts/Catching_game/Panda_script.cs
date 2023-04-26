using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panda_script : MonoBehaviour
{
    
    public GameObject PandaPreFab;
    public int numPanda = 10;
    public int minX = -2;
    public int maxX = 2;
    public int y = 0;

    bool IsPandaSpawned = false;

    void Start()
    {

         
    }

    void FixedUpdate()
    {
    }
    private void SpawnPanda(){
        //  for (int i = 0; i < numPanda; i++){
            
        //     Instantiate(PandaPreFab, new Vector3(x, y, 0f), Quaternion.identity);
        // } 
         if (IsPandaSpawned == false){
            float x = Random.Range(minX, maxX);
            Vector3 PanPosition = new Vector3(0, 4f, 0f); //Makes the panda spawn on a random range on x axis 
            Instantiate(PandaPreFab, PanPosition, Quaternion.identity); //Instantiate the prefab at the random loc
            IsPandaSpawned = true;
        }
    }
     private void OnTriggerEnter2D (Collider2D collision){
        
        SpawnPanda(); //Spawn new when collided
        Destroy(PandaPreFab);
        //IsPandaSpawned = false;
    }
}
