using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Panda_script : MonoBehaviour
{
    
    public GameObject PandaPreFab;
   
    public Stork_script storkScript;
    //[SerializeField] private TextMeshProUGUI tmp;

    public int numPanda = 1;
    public int minX = -2;
    public int maxX = 2;
    public int y = 0;
    bool IsPandaSpawned = false;

  

    void Start()
    {
        Debug.Log("Restart");
        //score = 0;
         
    }

    void FixedUpdate()
    {
        //tmp.text = score.ToString();
    }
    //The idea for making a bool to check the prefab, and calling the class on collision is from this video https://www.youtube.com/watch?v=IXDvl8aTM_M
    
    private void SpawnPanda(){
         if (IsPandaSpawned == false || numPanda < 10) { 
            numPanda ++;
            float x = Random.Range(minX, maxX);
            Vector3 PanPosition = new Vector3(0, 4f, 0f); //Makes the panda spawn on a random range on x axis
            Instantiate(PandaPreFab, PanPosition, Quaternion.identity); //Instantiate the prefab at the random loc (This line have been gotten through ChatBot)
            IsPandaSpawned = true;
            //Debug.Log(score);
           // 
        }
        
    }
     private void OnTriggerEnter2D (Collider2D collision){
        //storkScript.SpawnPanda(); //Spawn new when collided
        //storkScript.SpawnPanda();
        SpawnPanda();
        storkScript.score++;
        Destroy(PandaPreFab);
        
        //IsPandaSpawned = false;
    }
}
