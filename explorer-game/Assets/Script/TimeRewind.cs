using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct TransformSnapshot
{
    public Vector3 position;
    public Quaternion rotation;
    public float timestamp;
    public bool interacted;

    public TransformSnapshot(Vector3 pos, Quaternion rot, float time, bool interact)
    {
        position = pos;
        rotation = rot;
        timestamp = time;
        interacted = interact;
    }
}

public class TimeRewind : MonoBehaviour
{
    public static bool MockInteraction = false;

    private List<TransformSnapshot> snapshots = new List<TransformSnapshot>();
    public GameObject shadow;
    public float recordInterval = 0.1f;
    private float timer;
    private bool isRewinding = false;

    void Start()
    {
        if (shadow == null)
        {
            Debug.LogError("Shadow object is not assigned!");
            this.enabled = false;
            return;
        }
    }

    void FixedUpdate()
    {
        if (isRewinding) return; 

        timer += Time.fixedDeltaTime;
        RecordCurrentState();

        UpdateShadowPosition();

        if (Input.GetKeyDown(KeyCode.R) && !isRewinding)
        {
            StartCoroutine(SmoothRewind());
        }
    }

    private void RecordCurrentState()
    {
        if (snapshots.Count > Mathf.Floor(5f / Time.fixedDeltaTime)) // Assuming 5 seconds of memory
        {
            snapshots.RemoveAt(0);
        }

        snapshots.Add(new TransformSnapshot(transform.position, transform.rotation, Time.time, Input.GetKeyDown(KeyCode.Q)));
    }

    private void UpdateShadowPosition()
    {
        TransformSnapshot? targetSnapshot = null;
        foreach (var snapshot in snapshots)
        {
            if (snapshot.timestamp <= Time.time - 3f)
            {
                targetSnapshot = snapshot;
                break;
            }
        }

        if (targetSnapshot.HasValue)
        {
            shadow.SetActive(true);
            shadow.transform.position = targetSnapshot.Value.position;
            shadow.transform.rotation = targetSnapshot.Value.rotation;
            MockInteraction = targetSnapshot.Value.interacted;
        }
        else
        {
            MockInteraction = false;
            shadow.SetActive(false);
        }
    }

    private IEnumerator SmoothRewind()
    {
        isRewinding = true;

        float rewindDuration = 0.5f; 
        float startTime = Time.time;
        float endTime = startTime + rewindDuration;

        TransformSnapshot startSnapshot = new TransformSnapshot(transform.position, transform.rotation, Time.time, false);
        TransformSnapshot? endSnapshot = null;

        if (snapshots.Count > 0)
        {
            
            foreach (var snapshot in snapshots)
            {
                if (snapshot.timestamp <= Time.time - 3f)
                {
                    endSnapshot = snapshot;
                    break;
                }
            }
        }

        if (!endSnapshot.HasValue) yield break; 

        while (Time.time < endTime && endSnapshot.HasValue)
        {
            float t = (Time.time - startTime) / rewindDuration;
            transform.position = Vector3.Lerp(startSnapshot.position, endSnapshot.Value.position, t);
            transform.rotation = Quaternion.Lerp(startSnapshot.rotation, endSnapshot.Value.rotation, t);
            yield return null;
        }

        isRewinding = false;
    }
}
