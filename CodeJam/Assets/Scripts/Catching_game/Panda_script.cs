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
    bool IsPandaSpawned = false;

    public AudioClip soundsound;
    public int score = 0;


    void Start(){
        Debug.Log(score);
    }

    //The idea for making a bool to check the prefab, and calling the class on collision is from this video https://www.youtube.com/watch?v=IXDvl8aTM_M    
    private void SpawnPanda(){
        score++;
         if (IsPandaSpawned == false) { //Only spawn when there isnt a panda on screen
            Instantiate(PandaPreFab, spawnPos.transform.position, Quaternion.identity); //Instantiate the prefab at the random loc (This idea was originally from ChatBot, but changed since)
            IsPandaSpawned = true;
        }
        
    }
     private void OnTriggerEnter2D (Collider2D target){
        SpawnPanda(); //Spawn new when collided
        Destroy(PandaPreFab); //Destroy the Prefab 
        if(target.gameObject.tag == "Bed") //collison with the bed
        {
            
            //storkScript.score++; //The score goes up by one, each time they collide
            //tmp.text = storkScript.score.ToString(); //And update the score on screen
            tmp.text = score.ToString(); //And update the score on screen
            SoundManager.instance.PlaySound(soundsound); //And plays a sound effect
        } else {
           Timer.GameOver(); 
           //If you dont collide with the Bed tag, the collision happens with a cathing
           //That loses you the game
        }
        if(score >= 10) {
            Timer.NextScene(); //If the score is 10, change scene, from the timer script
        }
        
    }
}
