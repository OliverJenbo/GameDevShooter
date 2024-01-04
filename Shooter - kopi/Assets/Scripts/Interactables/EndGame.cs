using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameTrigger : Interactable
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Check if the player interacted
        {
            Interact();
        }
    }
    protected override void Interact()
    {
        Debug.Log("interacted with cake");

        // To load a scene (like a game over scene), use:
        // SceneManager.LoadScene("GameOverSceneName");
        SceneManager.LoadScene("FinishedGame"); 
    }
}



