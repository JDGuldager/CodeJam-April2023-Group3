using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [HideInInspector]
    public Vector3 targetPos;
    private float smoothMove = 1f;

    private void Start()
    {
        // Start position of camera is as I put it in the inspector
        targetPos = transform.position;
    }
    void Update()
    {
        // Moves the camera towards targetPos using Lerp
        transform.position = Vector3.Lerp(transform.position,targetPos, smoothMove * Time.deltaTime);
    }
}
