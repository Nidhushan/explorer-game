using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(AudioSource))]
public class PressurePlateController : MonoBehaviour
{
    public static int activePlates = 0;
    public int pressure = 0;
    public LampController Lamp;
    public GateController Gate;

    private Animator animator;
    private AudioSource audioSource;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (pressure == 0)
            {
                animator.SetBool("isActive", true);
                audioSource.Play();
                if (Lamp) Lamp.SetLit(true);
                if (Gate) Gate.OpenGate();
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
                if (Lamp) Lamp.SetLit(false);
                if (Gate) Gate.CloseGate();
            }

        }
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }
}
