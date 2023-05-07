using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackItController : MonoBehaviour
{
    public static StackItController Instance;
    public StackItSpawner spawnerScript;
    [HideInInspector] 
    public StackItBox currentBox;
    public CameraFollow cameraScript;
    private int moveCount;
    public Timer timerScript;

    [SerializeField]
    private float spawnRateBox = .5f;
    [SerializeField]
    private int whenToMoveCam = 5;
    [SerializeField]
    private int howMuchToMoveCam = 3;

    private void Awake()
    {
        // If the instance is not pointing to an existing place in the memory it should point to 'this'
        // Meaning the StackItController
        if (Instance == null) Instance = this;
    }

    private void Start()
    {
        spawnerScript.SpawnBox();
    }

    public void SpawnNewBox()
    {
        Invoke("NewBox", spawnRateBox);
    }
    void NewBox()
    {
        spawnerScript.SpawnBox();
    }

    public void MoveCamera()
    {
        moveCount++;
        if(moveCount == whenToMoveCam)
        {
            // Reset counter
            moveCount = 0;

           cameraScript.targetPos.y += howMuchToMoveCam;
        }
    }

    public void GameOver()
    {
      Timer.GameOver();
    }
}
