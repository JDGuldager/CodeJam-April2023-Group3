using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverBoxScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bacteria") {
            Invoke("RestartGame", 1f);
        }
    }

    private void RestartGame()
    {
        SceneManager.LoadScene("GameOver");
    }
}
