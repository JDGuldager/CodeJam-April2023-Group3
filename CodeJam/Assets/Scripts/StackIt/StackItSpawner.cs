using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackItSpawner : MonoBehaviour
{
    public GameObject boxPrefab;

    private void Start()
    {
      
    }
    // Spawns the box and transforms it's position to the position of the boxspawner
    public void SpawnBox()
    {
        GameObject box_obj = Instantiate(boxPrefab);
        Vector3 temp = transform.position;
        // I have to make z = 0, since it otherwise sets it to 10 for dome weird reason
        temp.z = 0f;
        box_obj.transform.position = temp;
    }
}
