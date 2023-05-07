using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class StackItSpawner : MonoBehaviour
{
    public GameObject boxPrefab;

    [SerializeField] private TextMeshProUGUI tmp;
    // Start at -1 since it adds when a box is spawned, and I spawn one on Start
    private int score = -1;
    public GameObject sky;
    public AudioClip stackSound;
    private int spawnSky = 10;
    [SerializeField]
    private int winConditon = 20;

    private void Start()
    {
        sky.SetActive(false);
    }
    private void Update()
    {
        // Updates the score
        tmp.text = score.ToString();

        if (score == spawnSky)
        {
            sky.SetActive(true);
        }
        if (score == winConditon)
        {
            // Set to restart all the minigames
            Timer.RestartGame();
        }
    }
    // Spawns the box and transforms it's position to the position of the boxspawner
    public void SpawnBox()
    {
        GameObject box_obj = Instantiate(boxPrefab);
        score++;
        // Set the box position to the game object I've placed the script on
        Vector3 temp = transform.position;
        // I have to make z = 0, since it otherwise sets it to 10 for dome weird reason
        temp.z = 0f;
        box_obj.transform.position = temp;
        // Play sound from soundmanager
        SoundManager.instance.PlaySound(stackSound);
    }
}
