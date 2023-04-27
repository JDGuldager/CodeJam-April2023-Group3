using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BacteriaSpawnerScript : MonoBehaviour
{
public GameObject enemyPrefab;
public float spawnInterval = 2.0f;
private float spawnTimer = 0.0f;
public Timer time;

    void Update()
{
    spawnTimer += Time.deltaTime;
    if (spawnTimer >= spawnInterval)
    {
        spawnTimer = 0.0f;
        float spawnX = Random.Range(-2f, 2f);
        float spawnY = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.95f, 0.0f)).y;
        Vector3 spawnPos = new Vector3(spawnX, spawnY, 0.0f);
        Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
    }

        CheckIfWinOrLose();
    }

public void CheckIfWinOrLose()
{
        if (Timer.timerTillNextScene <= 0f)
        {
            time.NextScene();
        }
    }
}