using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightScript : MonoBehaviour
{
    public RandomSpawn randomSpawn;
    public Sprite greenVirusSprite;
    private ScoreScript scoreScript;
    public AudioClip virusSound;

    private void Update()
    {
        VirusWinLose();
    }

    // checks if the score is zero or the time has run out
    public void VirusWinLose()
    {
        if (ScoreScript.scoreValue == 0)
        {
            Timer.NextScene();
        }

        if(Timer.timerTillNextScene <= 0f)
        {
            Timer.GameOver();
        }
    } 

    // called when an objecter enters the trigger area
    public void OnTriggerEnter2D(Collider2D other)
    {
        // checks if the object has the tag
        if (other.CompareTag("Virus"))
        {
            // makes the virus green
            other.GetComponent<SpriteRenderer>().sprite = greenVirusSprite;
            

            // changes the tag
            other.tag = "GreenVirus";

            // decreases the score by one
            ScoreScript.scoreValue--;

            // changes the sprite layer
            other.GetComponent<SpriteRenderer>().sortingOrder = 1;

            // spawns a new virus
            randomSpawn.InstantiateObjectInsideCollider();

            // plays an audioclip
            SoundManager.instance.PlaySound(virusSound);
        }
    }
}
