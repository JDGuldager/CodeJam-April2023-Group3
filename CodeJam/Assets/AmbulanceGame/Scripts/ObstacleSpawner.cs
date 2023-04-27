using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;

    private int randomPos;

    private int xAxis;
    // Start is called before the first frame update

    private void Start()
    {
        InvokeRepeating("Spawner", 0, 1);
    }

    


    private void Spawner()
    {
        
        randomPos = Random.Range(0, 2);
        if (randomPos == 0)
        {
            xAxis = -1;
        }
        else
        {
            xAxis = +1;
        }
            
        GameObject spawnedItem = Instantiate(obstaclePrefabs[Random.Range(0, 3)]);
        spawnedItem.transform.position = new Vector3(xAxis,12,0);
    }
}
