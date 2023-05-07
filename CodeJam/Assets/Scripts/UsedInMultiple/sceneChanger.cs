using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneChanger : MonoBehaviour
{
    public void LoadAScene(int sceneNum)
    {
        SceneManager.LoadScene(sceneNum);
        Timer.timerTillNextScene = 30f;
    }
}
