using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Spawns Cloud, and finds their spawn position and what direction they need to swim.
 */

public class CloudSpawner : MonoBehaviour
{
    public GameObject cloudPrefab;
    public float spawnrate;

    void Start()
    {
        // Calls the function SpawnCloud() every (1/spawnrate) seconds. (1/spawnrate) gives a number.
        InvokeRepeating("SpawnCloud", 0, 1/spawnrate);
    }

    // Spawns a Cloud
    public void SpawnCloud()
    {
        // Uses FindSpawnPosition to find a spawn position for the Cloud
        Vector2 spawnPos = FindSpawnPosition();

        // Instantiates the CloudPrefab, at the spawn position found above.
		// Quaternion.identity means it spawns with the rotation i has in the prefab CloudPrefab
        GameObject cloud = Instantiate(cloudPrefab, spawnPos, Quaternion.identity);

        // Checks if the Cloud spawns in the left or right side of the map
        if (spawnPos.x > 0)
        {
            // Makes the Cloud move from right to left when true, otherwise it moves from left to right.
            cloud.GetComponent<CloudMovement>().moveLeft = true;
        }
    }

    // Finds a valid spawn position and returns it as a Vector2 (A 2D position, x and y)
    public Vector2 FindSpawnPosition()
    {
        // Finds a random number between 0 and 1. The min value is inclusive and max value is exclusive.
        int x = Random.Range(0, 2);
         
        // Decides if the Cloud spawns in the left or right side. When x is 1, it spawn on the right. When x i -1 it spawns on the left
        if (x == 0)
        {
            x = 1;
        }
        else x = -1;

        // Gets the top right x and y position of the screen
        Vector3 screenPoint = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));

        // Finds a random spawn position. We use x that we found above to decide if it spawn on the left or right side of the screen.
        // And finds a random height(y) between the bottom and top of the of the screen. aka Random.Range(-(screenPoint.y), screenPoint.y).
        return new Vector2(screenPoint.x * x * 1.5f, Random.Range(-(screenPoint.y), screenPoint.y));
    }
}
