using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Panda_script : MonoBehaviour
{
    
    public GameObject PandaPreFab;
   public GameObject spawnPos;
    public Stork_script storkScript;
    //[SerializeField] private TextMeshProUGUI tmp;
[SerializeField] private TextMeshProUGUI tmp;
    public int numPanda = 1;
    public int minX = -2;
    public int maxX = 2;
    public int y = 0;
    bool IsPandaSpawned = false;

    //Vector3 PanPosition = new Vector3(2.5f, 4f, 0f); //Makes the panda spawn on a random range on x axis

    void Start()
    {
        Debug.Log("Restart");
        //score = 0;
         
    }

    void FixedUpdate()
    {
      
    }
    //The idea for making a bool to check the prefab, and calling the class on collision is from this video https://www.youtube.com/watch?v=IXDvl8aTM_M
    
    private void SpawnPanda(){
         if (IsPandaSpawned == false || spawnPos.transform.position.y < 3.9f) { 
            numPanda ++;
            float x = Random.Range(minX, maxX);
            //Vector3 PanPosition = new Vector3(2.5f, 4f, 0f); 
            Instantiate(PandaPreFab, spawnPos.transform.position, Quaternion.identity); //Instantiate the prefab at the random loc (This line have been gotten through ChatBot)
            IsPandaSpawned = true;
            

          
           // 
        }
        
    }
     private void OnTriggerEnter2D (Collider2D target){
        //storkScript.SpawnPanda(); //Spawn new when collided
        SpawnPanda();
        Destroy(PandaPreFab);
        if(target.gameObject.tag == "Bed")
        {
            Debug.Log("Registered" + storkScript.score);
            storkScript.score++;
            tmp.text = storkScript.score.ToString();
        }
        
        
    }
}
