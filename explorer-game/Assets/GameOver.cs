using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameController.state = GameState.InMenu;
        CheckpointManager.lastCheckpointPosition = Vector3.zero;
        SceneManager.LoadScene("start");

    }
}
