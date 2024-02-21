using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PressurePlateController : MonoBehaviour
{
    public static int activePlates = 0;
    public int pressure = 0;

    private Animator animator;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (pressure == 0)
            {
                animator.SetBool("isActive", true);
            }
            activePlates++;
            pressure++;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            activePlates--;
            pressure--;
            if (pressure == 0)
            {
                animator.SetBool("isActive", false);
            }

        }
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
}
