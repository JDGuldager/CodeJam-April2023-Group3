using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//kilder:
//https://gamedevbeginner.com/how-to-make-countdown-timer-in-unity-minutes-seconds/
//Chatgbt
public class Timer : MonoBehaviour
{
    public Text timeLeft;
    public bool timerIsRunning = false;

    [SerializeField]
    public float timeTillWin = 30f;

    private void Start()
    {
        // Starts the timer automatically
        timerIsRunning = true;
    }
    void Update()
    {
        if (timeTillWin > 0)
        {
            timeTillWin -= Time.deltaTime;
        }
        else
        {
            Invoke("WinGame", 1f);
        }

        DisplayTime();
    } 

public void WinGame(int SceneNum)
{
    SceneManager.LoadScene(0);
}

void DisplayTime()
{
float minutes = Mathf.FloorToInt(timeTillWin / 60);
float seconds = Mathf.FloorToInt(timeTillWin % 60);
timeLeft.text = string.Format("TIME LEFT: {0:00}:{1:00}", minutes, seconds);
}
}
