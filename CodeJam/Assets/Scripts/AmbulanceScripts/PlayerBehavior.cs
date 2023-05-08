using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//handles how the player is controlled. Attached to the Sensor game object
public class PlayerBehavior : MonoBehaviour
{
    public GameObject ambulance;
    private float yPos = -3f;
    private float leftX = -1f;
    private float rightX = 1f;
    
    //moves the ambulance to 1 of 2 set locations, based on where the sensor game object is moved in the editor
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "Left")
        {
            ambulance.transform.position = new Vector3(leftX, yPos, 0);
        }
        else if (col.gameObject.name == "Right")
        {
            ambulance.transform.position = new Vector3(rightX, yPos, 0);
        }
    }

}
