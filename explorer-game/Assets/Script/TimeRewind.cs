using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeRewind : MonoBehaviour
{
    private bool isRewinding = false;
    public float rewindTime = 3f;
    List<Vector2> positionsHistory;

    // Start is called before the first frame update
    void Start()
    {
        positionsHistory = new List<Vector2>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            StartRewind();
        }
        if (Input.GetKeyUp(KeyCode.R))
        {
            StopRewind();
        }
    }

    void FixedUpdate()
    {
        if (isRewinding)
        {
            Rewind();
        }
        else
        {
            Record();
        }
    }

    void Rewind()
    {
        if (positionsHistory.Count > 0)
        {
            transform.position = positionsHistory[0];
            positionsHistory.RemoveAt(0);
        }
        else
        {
            StopRewind();
        }
    }

    void Record()
    {
        if (positionsHistory.Count > Mathf.Floor(rewindTime / Time.fixedDeltaTime))
        {
            positionsHistory.RemoveAt(positionsHistory.Count - 1);
        }
        positionsHistory.Insert(0, transform.position);
    }

    public void StartRewind()
    {
        isRewinding = true;
        GetComponent<Rigidbody2D>().isKinematic = true; // Prevents physics from affecting the player while rewinding
        TimeController.PauseTime();
    }

    public void StopRewind()
    {
        isRewinding = false;
        GetComponent<Rigidbody2D>().isKinematic = false; // Re-enables physics
        TimeController.ResumeTime();
    }
}
