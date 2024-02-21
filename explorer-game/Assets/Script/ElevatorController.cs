using UnityEngine;
using UnityEngine.SceneManagement;

public class ElevatorController : MonoBehaviour
{
    public string nextSceneName; 

    private void Update()
    {
        if (PressurePlateController.activePlates == 2 && Input.GetKeyDown(KeyCode.Q))
        {
            SceneManager.LoadScene(nextSceneName);
        }
    }
}
