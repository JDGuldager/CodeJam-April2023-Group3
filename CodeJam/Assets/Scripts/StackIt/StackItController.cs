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
    private void Awake()
    {
        // watch awesome tuts singleton tutorial
        if (Instance == null) Instance = this;
    }
    private void Start()
    {
        spawnerScript.SpawnBox();
    }


 
    public void MoveCamera()
    {
        moveCount++;
        if(moveCount == 5)
        {
            moveCount = 0;
           cameraScript.targetPos.y += 3f;
        }
    }
    public void SpawnNewBox()
    {
        Invoke("NewBox", .5f);
    }
    void NewBox()
    {
        spawnerScript.SpawnBox();
    }
    // Might need to remove this::
    public void RestartGame()
    {
        timerScript.GameOver();
    }
}
