using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class CountDown : MonoBehaviour
{
    public Slider countdownBar; //Slider of bar
    public Image countDownImage; //Image of bar
    public float duration = 10f; //Time duration
    public TextMeshProUGUI timerText;

    void Start()
    {
        countdownBar.maxValue = duration; //Make sure maxvalue is the duration
        countdownBar.value = duration; //Changes value to duration
        StartCoroutine(Countdown()); //Starts timer
    }

	void Update()
	{
        timerText.text = duration.ToString();
    }

	IEnumerator Countdown()
    {
        float timeLeft = duration;

        while (timeLeft > 0f)
        {
            timeLeft -= Time.deltaTime;
            countdownBar.value = timeLeft;
            duration = Mathf.Round(timeLeft);
            if (duration <= 3)
            {
                timerText.color = Color.red;
                countDownImage.color = Color.red;
            } else
            {
                timerText.color = Color.white;
                countDownImage.color = Color.white;
            }

            yield return new WaitForEndOfFrame();
        }

        SceneManager.LoadScene(0);
    }
}


