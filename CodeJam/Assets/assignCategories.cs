using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class assignCategories : MonoBehaviour
{
    // Enum for both categories
    public enum Category { Injured, Recovered };

    public Category objectCategory;
    public Sprite characterInjuredSprite, characterRecoveredSprite;

    void Start()
    {

        float randomNum = Random.Range(0f, 1f);

        if (randomNum < 0.5f)
        {
            objectCategory = Category.Injured;
            gameObject.GetComponent<SpriteRenderer>().sprite = characterInjuredSprite;
        }
        else
        {
            objectCategory = Category.Recovered;
            gameObject.GetComponent<SpriteRenderer>().sprite = characterRecoveredSprite;
        }
    }
}
