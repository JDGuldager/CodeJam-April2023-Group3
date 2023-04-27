using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }
}
