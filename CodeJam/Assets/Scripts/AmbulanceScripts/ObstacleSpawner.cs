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

    public int repeatCounter;

    [SerializeField] private int spawnStartTimer = 3;

    [SerializeField] private int repeatRate = 1;
    // Start is called before the first frame update

    private void Start()
    {
        InvokeRepeating("Spawner", spawnStartTimer, repeatRate);
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

        if (repeatCounter <= 19)
        {
            GameObject spawnedItem = Instantiate(obstaclePrefabs[Random.Range(0, 3)]);
            spawnedItem.transform.position = new Vector3(xAxis,12,0);
            repeatCounter++;
        }
        
        
        Debug.Log(repeatCounter);
    }
}
