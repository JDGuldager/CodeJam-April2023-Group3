using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanTiles : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("DirtyObject"))
        {
            Destroy(other.gameObject);
        }
    }

}
