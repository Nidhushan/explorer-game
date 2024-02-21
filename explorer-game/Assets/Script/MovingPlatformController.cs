using System.Collections;
using UnityEngine;

public class MovingPlatformController : MonoBehaviour
{
    public float moveSpeed = 2.0f; 
    private Vector3 startPosition; 
    private Vector3 targetPosition; 
    public float moveDistance = 5.0f; 
    public float returnSpeed = 0.5f; 

    private void Start()
    {
        startPosition = transform.position; 
        targetPosition = new Vector3(startPosition.x - moveDistance, startPosition.y, startPosition.z); 
    }

    public void MoveLeft()
    {
        StopAllCoroutines(); 
        StartCoroutine(MoveTowards(targetPosition));
    }

    private IEnumerator MoveTowards(Vector3 target)
    {
        while (Vector3.Distance(transform.position, target) > 0.01f)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, moveSpeed * Time.deltaTime);
            yield return null;
        }

        StartCoroutine(ReturnToStart());
    }

    private IEnumerator ReturnToStart()
    {
        yield return new WaitForSeconds(2.0f);

        while (Vector3.Distance(transform.position, startPosition) > 0.01f)
        {
            transform.position = Vector3.MoveTowards(transform.position, startPosition, returnSpeed * Time.deltaTime);
            yield return null;
        }
    }
}
