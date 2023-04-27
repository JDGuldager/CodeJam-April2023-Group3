using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Panda_script : MonoBehaviour
{
    
    public GameObject PandaPreFab;
    public GameObject spawnPos;
    public Stork_script storkScript;
    [SerializeField] private TextMeshProUGUI tmp;
    //private int minX = -2;
   // private int maxX = 2;
    public int y = 0;
    bool IsPandaSpawned = false;

    public AudioClip soundsound;

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
            //float x = Random.Range(minX, maxX); //The range the 
            //Vector3 PanPosition = new Vector3(2.5f, 4f, 0f); 
            Instantiate(PandaPreFab, spawnPos.transform.position, Quaternion.identity); //Instantiate the prefab at the random loc (This line was originally from ChatBot, but changed since)
            IsPandaSpawned = true;
 
        }
        
    }
     private void OnTriggerEnter2D (Collider2D target){
        SpawnPanda(); //Spawn new when collided
        Destroy(PandaPreFab); //Destroy the Prefab 
        if(target.gameObject.tag == "Bed")
        {
            Debug.Log("Registered" + storkScript.score);
            storkScript.score++; //The score goes up by one, each time they collide
            tmp.text = storkScript.score.ToString(); //And update the score on screen
            SoundManager.instance.PlaySound(soundsound);
        } else {
           Timer.GameOver();
        }
        if(storkScript.score > 10) {
            Timer.NextScene(); //If the score is 10, change scene
        }
        
    }
}
