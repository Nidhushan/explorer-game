using UnityEngine;

public class PressurePlateController : MonoBehaviour
{
    public static int activePlates = 0;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            activePlates++;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            activePlates--;
        }
    }
}
