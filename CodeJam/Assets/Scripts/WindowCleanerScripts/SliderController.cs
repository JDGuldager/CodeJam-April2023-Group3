using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
    int progress;
    int startProgress = 0; // Variable replacing Magic Number (MN).

    [SerializeField]
    int maxSliderValue = 212; // Variable replacing MN.
    float timeOver = 0f; // Variable replacing MN.

    public Slider slider;
    public sceneChanger changeScene;

    public Animator m_Animator;
    public bool m_Soap = false;

    public AudioClip blopsound;

    float timeBetweenAnimationAndSound = 4; // Variable replacing MN.

    private void Start()
    {
        progress = startProgress; // Replacement of MN.
        slider.value = progress;
    }

    private void Update()
    {
        if (m_Soap == false)
        {
            StartCoroutine(AnimationMethod());
        }

        CheckIfWinOrLose();
    }
    IEnumerator AnimationMethod()
    {
        m_Animator.SetBool("m_Soap", true);
        m_Soap = true;
        SoundManager.instance.PlaySound(blopsound);
        yield return new WaitForSeconds(timeBetweenAnimationAndSound); // Replacement of MN.
        m_Animator.SetBool("m_Soap", false);
        m_Soap = false;
    }

    public void UpdateProgress()
    {
        progress++;
        slider.value = progress;
    }

    public void CheckIfWinOrLose()
    {
        if (slider.value == maxSliderValue) // Replacement of MN. 
        {
            Timer.NextScene();
        }

        if (Timer.timerTillNextScene <= timeOver) // Replacement of MN.
        {
            Timer.GameOver();
        }
    }
}
