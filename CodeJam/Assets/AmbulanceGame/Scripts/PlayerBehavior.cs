using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    public GameObject ambulance;
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "Venstre")
        {
            ambulance.transform.position = new Vector3(1, -3, 0);
        }
        else if (col.gameObject.name == "Højre")
        {
            ambulance.transform.position = new Vector3(-1, -3, 0);
        }
    }


    private void Start()
    {
        
    }

   
}
