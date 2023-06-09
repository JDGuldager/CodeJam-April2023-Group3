using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
//using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//kilder:
//https://gamedevbeginner.com/how-to-make-countdown-timer-in-unity-minutes-seconds/
public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timeLeft;
    public bool timerIsRunning = false;
    public static float timerTillNextScene = 30f;
    //public bool conditionHasBeenMet = true;

    public bool con = false;

    private void Start()
    {
        // Starts the timer automatically
        timerIsRunning = true;

    }
    void Update()
    {
            if (timerTillNextScene > 0)
            {
                timerTillNextScene -= Time.deltaTime;
            }

        DisplayTime();
    }

    public static void NextScene()
    {
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        DataHolder.totalScore++;
        timerTillNextScene = 30f;
    }

    public static void GameOver()
    {
        SceneManager.LoadScene("GameOver");
        timerTillNextScene = 30f;
    }

    public static void RestartGame()
    {
        SceneManager.LoadScene("Ambulance");
        timerTillNextScene = 30f;
    }
    void DisplayTime()
    {
    float minutes = Mathf.FloorToInt(timerTillNextScene / 60);
    float seconds = Mathf.FloorToInt(timerTillNextScene % 60);
    timeLeft.text = string.Format("TID TILBAGE: {0:00}:{1:00}", minutes, seconds);
    }

    }
