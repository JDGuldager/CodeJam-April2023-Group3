using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class FinalScore : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI tmp;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        tmp.text = ("SCORE: " + DataHolder.totalScore.ToString());
    }
}
