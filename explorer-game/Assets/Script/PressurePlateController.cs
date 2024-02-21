using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PressurePlateController : MonoBehaviour
{
    public static int activePlates = 0;

    private Animator animator;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            animator.SetBool("isActive", true);
            activePlates++;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            animator.SetBool("isActive", false);
            activePlates--;
        }
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
}
