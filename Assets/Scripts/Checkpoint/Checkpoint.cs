using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Checkpoint : MonoBehaviour
{
    public Transform checkpointSpawnPosition;
    [SerializeField] bool isSpawnpoint = false;
    [Header("Set Checkpoint (Player > This)")]
    public UnityEvent setPlayerCheckpointOnCollision;

    private void Awake()
    {
        if (!isSpawnpoint) return;
        setPlayerCheckpointOnCollision.Invoke();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            setPlayerCheckpointOnCollision.Invoke();
        }
    }

}
