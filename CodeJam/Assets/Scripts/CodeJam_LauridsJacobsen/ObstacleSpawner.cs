using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;
//Handles how obstacles are spawned. Attached to the ObstacleSpawner game object
public class ObstacleSpawner : MonoBehaviour
{
    public GameObject[] obstaclePrefabs; //Array of the obstacle prefabs
    private int randomPos;
    private int xAxis;
    public int repeatCounter;
    public int repeatMax = 20;
    [SerializeField] private float spawnStartTimer = 3f;
    [SerializeField] private float repeatRate = 1f;
    private float obsYPos = 12f;
    
    private void Start()
    {
        //Calls the "Spawner" method with set intervals for start time and repeat rate
        InvokeRepeating("Spawner", spawnStartTimer, repeatRate);
    }

    //Spawns obstacles
    private void Spawner()
    {
        //randomizes whether obstacles spawn in the right or left lane of the road
        randomPos = Random.Range(0, 2);
        if (randomPos == 0)
        {
            xAxis = -1;
        }
        else
        {
            xAxis = +1;
        }
        
        //Spawns obstacles until repeatMax (20) has been spawned
        if (repeatCounter <= repeatMax)
        {
            GameObject spawnedItem = Instantiate(obstaclePrefabs[Random.Range(0, 3)]);
            spawnedItem.transform.position = new Vector3(-1,obsYPos,0);
            repeatCounter++;
        }
        Debug.Log(repeatCounter);
    }
    
}
