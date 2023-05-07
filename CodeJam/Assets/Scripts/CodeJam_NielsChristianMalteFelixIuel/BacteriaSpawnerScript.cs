using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BacteriaSpawnerScript : MonoBehaviour
{
public GameObject bacteriaPrefab;
public float spawnInterval = 2.0f;
private float spawnTimer = 0.0f;
    //construct to remove magic numbers
    private const float MinXSpawn = -2f;
    private const float MaxXSpawn = 2f;
    private const float ViewportX = 0.5f;
    private const float ViewportY = 0.95f;
    private const float ViewportZ = 0.0f;
    private const float spawnZ = 0.0f;


    void Update()
{
    spawnTimer += Time.deltaTime;
    if (spawnTimer >= spawnInterval)
    {
            spawnTimer += Time.deltaTime;
            if (spawnTimer >= spawnInterval)
            {
                spawnTimer = 0.0f;
                float spawnX = Random.Range(MinXSpawn, MaxXSpawn);
                float spawnY = Camera.main.ViewportToWorldPoint(new Vector3(ViewportX, ViewportY, ViewportZ)).y;
                Vector3 spawnPos = new Vector3(spawnX, spawnY, spawnZ);
                Instantiate(bacteriaPrefab, spawnPos, Quaternion.identity);
            }
    }

        CheckIfWinOrLose();
    }

public void CheckIfWinOrLose()
{
        if (Timer.timerTillNextScene <= 0f)
        {
            Timer.NextScene();
        }
    }
}