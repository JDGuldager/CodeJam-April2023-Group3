using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightScript : MonoBehaviour
{
    public RandomSpawn randomSpawn;
    public Sprite greenVirusSprite;
    private ScoreScript scoreScript;
    public AudioClip virusSound;

    public void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Virus"))
        {
            //Make green
            other.GetComponent<SpriteRenderer>().sprite = greenVirusSprite;
            

            //Change tag
            other.tag = "GreenVirus";
            ScoreScript.scoreValue--;

            //Chnage sprite layer
            other.GetComponent<SpriteRenderer>().sortingOrder = 1;

            //Spawn new virus
            randomSpawn.InstantiateObjectInsideCollider();
            SoundManager.instance.PlaySound(virusSound);
        }
    }
}
