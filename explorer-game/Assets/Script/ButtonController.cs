using TMPro;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class ButtonController : MonoBehaviour
{
    public GateController gate;
    public TextMeshPro hint;

    private bool isPlayerNear = false;
    private bool isShadowNear = false;
    private Animator animator;

    void Update()
    {
        if (isPlayerNear && Input.GetKeyDown(KeyCode.Q) || (isShadowNear && TimeRewind.MockInteraction))
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
        hint.gameObject.SetActive(isPlayerNear || isShadowNear);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            var player = collision.GetComponentInChildren<PlayerController>();
            if (player.IsGhost) isShadowNear = true;
            if (!player.IsGhost) isPlayerNear = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            var player = collision.GetComponentInChildren<PlayerController>();
            if (player.IsGhost) isShadowNear = true;
            if (!player.IsGhost) isPlayerNear = true;
        }
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
}
