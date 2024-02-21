using UnityEngine;

[RequireComponent(typeof(Animator))]
public class ButtonController : MonoBehaviour
{
    public GateController gate; 
    private bool isPlayerNear = false;
    private Animator animator;

    void Update()
    {
        if (isPlayerNear && Input.GetKeyDown(KeyCode.Q))
        {
            animator.SetTrigger("pressed");
            if (gate.IsOpen)
            {
                gate.CloseGate();
            }
            else
            {
                gate.OpenGate();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerNear = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerNear = false;
        }
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
}
