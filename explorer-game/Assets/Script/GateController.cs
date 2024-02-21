using UnityEngine;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Animator))]
public class GateController : MonoBehaviour
{
    public bool IsOpen = false;

    private Animator animator;
    private Collider2D collider;

    public void OpenGate()
    {
        IsOpen = true;
        collider.enabled = !IsOpen;
        animator.SetBool("isOpen", IsOpen);
    }

    public void CloseGate()
    {
        IsOpen = false;
        collider.enabled = !IsOpen;
        animator.SetBool("isOpen", IsOpen);
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
        collider = GetComponent<Collider2D>();
        if (IsOpen)
        {
            CloseGate();
        }
        else
        {
            OpenGate();
        }
    }
}
