using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Checkpoint : MonoBehaviour
{
    private Animator animator;
    private ParticleSystem particle;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            CheckpointManager.SetCheckpoint(transform.position);

            animator.SetBool("unlocked", true);
            particle.Play();
        }
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
        particle = GetComponentInChildren<ParticleSystem>();
    }
}
