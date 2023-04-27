using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreScript : MonoBehaviour
{
    public static int scoreValue = 5;
    [SerializeField] TextMeshProUGUI scoreText;

    // Start is called before the first frame update
    void Start()
    {
        scoreValue = 5;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = ("MANGLER: " + scoreValue.ToString());

    }
}
