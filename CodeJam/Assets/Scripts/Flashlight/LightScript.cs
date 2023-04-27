using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightScript : MonoBehaviour
{
    public RandomSpawn randomSpawn;
    public Sprite greenVirusSprite;

    public void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Virus"))
        {
            //Make green
            other.GetComponent<SpriteRenderer>().sprite = greenVirusSprite;
            

            //Change tag
            other.tag = "GreenVirus";
            

            //Chnage sprite layer
            other.GetComponent<SpriteRenderer>().sortingOrder = 1;

            //Spawn new virus
            randomSpawn.InstantiateObjectInsideCollider();
        }
    }
}
