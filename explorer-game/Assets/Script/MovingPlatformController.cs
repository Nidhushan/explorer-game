using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformController : MonoBehaviour
{
    public float moveSpeed = 2.0f;

    public Transform targetTransform;
    public bool IsMovingTowardsTarget = false;

    public List<GameObject> passengers;

    private Vector3 startPosition;
    private Vector3 targetPosition => targetTransform.position;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            passengers.Add(collision.gameObject);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            passengers.Remove(collision.gameObject);
        }
    }

    public void Toggle()
    {
        IsMovingTowardsTarget = !IsMovingTowardsTarget;
    }

    private void Start()
    {
        startPosition = transform.position; 
    }

    private void Update()
    {
        Vector3 oldPos = transform.position;
        if (IsMovingTowardsTarget)
        {
            if (Vector3.Distance(transform.position, targetPosition) > 0.01f)
            {
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
            }
        }
        else
        {
            if (Vector3.Distance(transform.position, startPosition) > 0.01f)
            {
                transform.position = Vector3.MoveTowards(transform.position, startPosition, moveSpeed * Time.deltaTime);
            }
        }
        Vector3 deltaMovement = transform.position - oldPos;
        foreach (GameObject passenger in passengers)
        {
            passenger.transform.position += deltaMovement;
        }
    }
}
