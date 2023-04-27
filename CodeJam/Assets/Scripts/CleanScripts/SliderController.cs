using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
    int progress;
    public Slider slider;
    public sceneChanger changeScene;
    public Timer time;

    public Animator m_Animator;
    public bool m_Soap = false;

    private void Start()
    {
        progress = 0;
        slider.value = progress;
    }

    private void Update()
    {
        if (m_Soap == false)
        {
            StartCoroutine(AnimationMethod());
        }
    }
    IEnumerator AnimationMethod()
    {
        m_Animator.SetBool("m_Soap", true);
        m_Soap = true;
        yield return new WaitForSeconds(4);
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
        if (slider.value == 212)
        {
            time.con = true;
        }
    }
}
