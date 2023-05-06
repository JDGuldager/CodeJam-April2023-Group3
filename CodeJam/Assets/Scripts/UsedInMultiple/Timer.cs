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

    float timeOver = 0f; // Variable replacing MN.

    static int nextInBuildIndex = 1; // Variable replacing MN.

    static float timerStartAt = 30f; // Variable replacing MN.

    static float minute = 60f; // Variable replacing MN.

    static float increaseMoveSpeed = 100;

    private void Start()
    {
        // Starts the timer automatically
        timerIsRunning = true;
    }

    void Update()
    {
       if (timerTillNextScene > timeOver) // Replacement of MN.
       {
           timerTillNextScene -= Time.deltaTime;
       }

        DisplayTime();

        CheckIfSceneIsMainMenu();
    }

    public static void NextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + nextInBuildIndex); // Replacement of MN.
        DataHolder.totalScore++;
        timerTillNextScene = timerStartAt; // Replacement of MN.
    }

    public static void GameOver()
    {
        SceneManager.LoadScene("GameOver");
        timerTillNextScene = timerStartAt; // Replacement of MN.
    }

    public static void RestartGame()
    {
        SceneManager.LoadScene("Ambulance");
        timerTillNextScene = timerStartAt; // Replacement of MN.

        SensorController.moveSpeed += increaseMoveSpeed;
    }

    private void CheckIfSceneIsMainMenu()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            DataHolder dataHolder = FindObjectOfType<DataHolder>();
            
            Destroy(dataHolder.gameObject);
        }
    }

    void DisplayTime()
    {
        float minutes = Mathf.FloorToInt(timerTillNextScene / minute); // Replacement of MN.
        float seconds = Mathf.FloorToInt(timerTillNextScene % minute); // Replacement of MN.
        timeLeft.text = string.Format("TID TILBAGE: {0:00}:{1:00}", minutes, seconds);
    }

    }
