using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanTiles : MonoBehaviour
{
    private SliderController slider;

    private void Start()
    {
        slider = GetComponent<SliderController>();
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("DirtyObject"))
        {
            Destroy(other.gameObject);
            slider.UpdateProgress();
            slider.CheckIfWinOrLose();
        }
    }
}
