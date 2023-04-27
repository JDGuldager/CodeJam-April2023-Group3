using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
   // private SpriteRenderer sprite;
    private GameObject obj;
    public GameObject canvas;
    // Start is called before the first frame update
    void Start()
    {
        canvas.gameObject.SetActive(false);
       // sprite = GetComponent<SpriteRenderer>();
        obj = GetComponent<GameObject>();
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            canvas.gameObject.SetActive(true);
            Time.timeScale = 1;
           // sprite.enabled = false;
            gameObject.SetActive(false);
        }
    }
}
