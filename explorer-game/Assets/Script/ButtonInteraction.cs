using TMPro;
using Unity.Burst.CompilerServices;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class ButtonInteraction : MonoBehaviour
{
    public MovingPlatformController movingPlatform;
    public TextMeshPro hint;

    private bool isPlayerNear = false;
    private bool isShadowNear = false;
    private Animator animator;
    private AudioSource audioSource;

    void Update()
    {
        if ((isPlayerNear && Input.GetKeyDown(KeyCode.Q)) || (isShadowNear && TimeRewind.MockInteraction))
        {
            movingPlatform.Toggle();
            audioSource.Play();
            animator.SetBool("atLeft", movingPlatform.IsMovingTowardsTarget);
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
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }
}
