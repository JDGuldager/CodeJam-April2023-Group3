using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class StackItSpawner : MonoBehaviour
{
    public GameObject boxPrefab;
    [SerializeField] private TextMeshProUGUI tmp;
    private int score = -1;
    public GameObject sky;
    private void Start()
    {
        sky.SetActive(false);
    }
    private void Update()
    {
        tmp.text = score.ToString();
        if (score == 10)
        {
            sky.SetActive(true);
        }
    }
    // Spawns the box and transforms it's position to the position of the boxspawner
    public void SpawnBox()
    {
        GameObject box_obj = Instantiate(boxPrefab);
        score++;
        Vector3 temp = transform.position;
        // I have to make z = 0, since it otherwise sets it to 10 for dome weird reason
        temp.z = 0f;
        temp.x = Random.Range(0, 2);
        box_obj.transform.position = temp;
    }
}
