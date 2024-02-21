using UnityEngine;

public class ButtonInteraction : MonoBehaviour
{
    public MovingPlatformController movingPlatform; 
    private bool isPlayerNear = false;
    private Animator animator;

    void Update()
    {
        if (isPlayerNear && Input.GetKeyDown(KeyCode.Q))
        {
            movingPlatform.Toggle();
            animator.SetBool("atLeft", movingPlatform.IsMovingTowardsTarget);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = false;
        }
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
}
