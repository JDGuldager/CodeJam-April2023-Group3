using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    static float increaseMoveSpeed = 10;

    static float decreaseTimer = 5;

    static bool didFunction = false;

    static float minTimerTillNextScene = 11f;

    static float timerOriginal = 30f;

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
    }

    public static void NextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + nextInBuildIndex); // Replacement of MN.
        DataHolder.totalScore++;

        if (didFunction == true && timerTillNextScene >= minTimerTillNextScene)
        {
            timerTillNextScene -= decreaseTimer;
            timerStartAt -= decreaseTimer;

            didFunction = false;
        }
        else
        timerTillNextScene = timerStartAt; // Replacement of MN.
    }

    public static void GameOver()
    {
        SceneManager.LoadScene("GameOver");
        
        SensorController.moveSpeed = SensorController.startMoveSpeed;

        timerStartAt = timerOriginal;
        timerTillNextScene = timerStartAt; // Replacement of MN.

        didFunction = false;
    }

    public static void RestartGame()
    {
        SceneManager.LoadScene("Ambulance");
        
        // timerTillNextScene = timerStartAt; // Replacement of MN.

        SensorController.moveSpeed += increaseMoveSpeed;

        didFunction = true;
    }

    void DisplayTime()
    {
        float minutes = Mathf.FloorToInt(timerTillNextScene / minute); // Replacement of MN.
        float seconds = Mathf.FloorToInt(timerTillNextScene % minute); // Replacement of MN.
        timeLeft.text = string.Format("TID TILBAGE: {0:00}:{1:00}", minutes, seconds);
    }

    }
