using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    public static Vector3 lastCheckpointPosition = Vector3.zero;
    public Transform init;

    public static void SetCheckpoint(Vector3 checkpointPosition)
    {
        lastCheckpointPosition = checkpointPosition;
    }

    private void Start()
    {
        if (lastCheckpointPosition == Vector3.zero) 
        {
            lastCheckpointPosition = init.position;
        }
    }
}
