using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ElevatorController : MonoBehaviour
{
    public string nextSceneName;
    public TextMeshPro hint;

    private bool isPlayerNear = false;
    private bool isShadowNear = false;

    private void Update()
    {
        if (PressurePlateController.activePlates == 1 && Input.GetKeyDown(KeyCode.Q) && isPlayerNear)
        {
            SceneManager.LoadScene(nextSceneName);
        }
        hint.gameObject.SetActive(isPlayerNear || isShadowNear);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            var player = other.GetComponentInChildren<PlayerController>();
            if (player.IsGhost) isShadowNear = true;
            if (!player.IsGhost) isPlayerNear = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            var player = other.GetComponentInChildren<PlayerController>();
            if (player.IsGhost) isShadowNear = false;
            if (!player.IsGhost) isPlayerNear = false;
        }
    }

    private void Start()
    {
        GetComponentInChildren<SpriteRenderer>().enabled = false;
    }
}
