using System.Collections;
using UnityEngine;

public class MovingPlatformController : MonoBehaviour
{
    public float moveSpeed = 2.0f;

    public Transform targetTransform;
    public bool IsMovingTowardsTarget = false;

    private Vector3 startPosition;
    private Vector3 targetPosition => targetTransform.position;

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
    }
}
