using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(AudioSource))]
public class Checkpoint : MonoBehaviour
{
    private Animator animator;
    private ParticleSystem particle;
    private AudioSource audioSource;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            CheckpointManager.SetCheckpoint(transform.position);

            if (!animator.GetBool("unlocked"))
            {
                particle.Play();
                audioSource.Play();
            }
            animator.SetBool("unlocked", true);
        }
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
        particle = GetComponentInChildren<ParticleSystem>();
        audioSource = GetComponent<AudioSource>();
    }
}
