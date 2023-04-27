using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
//using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//kilder:
//https://gamedevbeginner.com/how-to-make-countdown-timer-in-unity-minutes-seconds/
public class Timer : MonoBehaviour
{
    public Text timeLeft;
    public bool timerIsRunning = false;
    public float timeTillWin = 30f;
    public float timeTillLose = 30f;
    public bool WinTimerBool = false;
    public bool LoseTimerBool = false;

    private void Start()
    {
        // Starts the timer automatically
        timerIsRunning = true;

    }
    void Update()
    {
        if (WinTimerBool == true)
        {
            DisplayWinTime();
            if (timeTillWin > 0)
            {
                timeTillWin -= Time.deltaTime;
            }
            else
            {
                Invoke("WinGame", 1f);
            }
        }

        if (LoseTimerBool == true)
        {
            DisplayLoseTime();
            if (timeTillLose > 0)
            {
                timeTillLose -= Time.deltaTime;
            }
            else
            {
                Invoke("LoseGame", 1f);
            }
        }
    } 

public void WinGame(int SceneNum)
{
    SceneManager.LoadScene(0);
}

public void LoseGame(int SceneNum)
    {
        SceneManager.LoadScene(0);
    }
void DisplayWinTime()
{
float minutes = Mathf.FloorToInt(timeTillWin / 60);
float seconds = Mathf.FloorToInt(timeTillWin % 60);
timeLeft.text = string.Format("TIME LEFT: {0:00}:{1:00}", minutes, seconds);
}

void DisplayLoseTime()
{
float minutes = Mathf.FloorToInt(timeTillLose / 60);
float seconds = Mathf.FloorToInt(timeTillLose % 60);
timeLeft.text = string.Format("TIME LEFT: {0:00}:{1:00}", minutes, seconds);
}
}
