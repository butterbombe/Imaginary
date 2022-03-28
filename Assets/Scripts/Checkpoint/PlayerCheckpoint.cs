using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCheckpoint : MonoBehaviour
{

    [SerializeField] private Checkpoint lastCheckpoint;

    private void Start()
    {
        ResetToLastCheckpoint();
    }

    public void SetCheckpoint(Checkpoint checkpoint)
    {
        lastCheckpoint = checkpoint;
    }

    public void ResetToLastCheckpoint()
    {
        transform.position = lastCheckpoint.checkpointSpawnPosition.position;
    }

}
