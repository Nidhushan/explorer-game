using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float jumpForce = 500f;
    public float dashSpeed = 10f;
    public Color GhostColor = Color.white;
    public bool IsGhost = false;

    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private bool isGrounded = true;
    private bool isDashing = false;

    public GameObject shadowPrefab; 
    public float shadowDuration = 5.0f;
    private bool shadowExists = false;

    public void Ghostify()
    {
        spriteRenderer.color = GhostColor;
        IsGhost = true;
    }

    void Start()
    {
        transform.position = CheckpointManager.lastCheckpointPosition;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (IsGhost)
        {
            Ghostify();
        }
    }

    void Update()
    {
        if (!isDashing)
        {
            // Move
            float move = Input.GetAxis("Horizontal");
            rb.velocity = new Vector2(move * moveSpeed, rb.velocity.y);


            if (rb.velocity.x > 0) { 
                transform.localScale = new Vector2(1, 1);
            }
            else
            {
                transform.localScale = new Vector2(-1, 1);
            }

            if (Mathf.Abs(move) > 0)
            {
                animator.SetBool("isWalking", true);
            }
            else
            {
                animator.SetBool("isWalking", false);
            }
        }

        // Jump
        if (Input.GetButtonDown("Jump") && isGrounded && !isDashing)
        {
            rb.AddForce(new Vector2(0, jumpForce));
            isGrounded = false;
        }

        // Dash
        if (Input.GetKeyDown(KeyCode.E) && !isDashing)
        {
            StartCoroutine(Dash());
        }

        if (Input.GetKeyDown(KeyCode.F) && !shadowExists)
        {
            CreateShadow();
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Player"))
        {
            isGrounded = true;
        }
    }

    private IEnumerator Dash()
    {
        isDashing = true;
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0;
        rb.velocity = new Vector2(transform.localScale.x * dashSpeed, 0);
        yield return new WaitForSeconds(0.3f); 
        rb.gravityScale = originalGravity;
        isDashing = false;
    }
    void CreateShadow()
    {
        GameObject shadowInstance = Instantiate(shadowPrefab, transform.position, Quaternion.identity);
        shadowInstance.GetComponent<PlayerController>().Ghostify();
        shadowExists = true; 

        Destroy(shadowInstance, shadowDuration);
        Invoke("ShadowDestroyed", shadowDuration); 
    }
    void ShadowDestroyed()
    {
        shadowExists = false; 
    }
}
