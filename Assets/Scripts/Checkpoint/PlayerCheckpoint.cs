using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCheckpoint : MonoBehaviour
{

    [SerializeField] private Checkpoint lastCheckpoint;
    [SerializeField] private float resetTime = 0.2f;
    [SerializeField] private ParticleSystem deathParticle;
    private void Start()
    {
        InitialCheckpointReset();
    }
    private void InitialCheckpointReset()
    {
        transform.position = lastCheckpoint.checkpointSpawnPosition.position;
    }

    public void SetCheckpoint(Checkpoint checkpoint)
    {
        lastCheckpoint = checkpoint;
    }

    public void ResetToLastCheckpoint()
    {
        StartCoroutine(ResetCoroutine());
    }

    IEnumerator ResetCoroutine()
    {
        ChangePlayerActiveState(false);
        ParticleSystem particleSys = Instantiate(deathParticle, gameObject.transform);
        yield return new WaitForSeconds(resetTime);
        transform.position = lastCheckpoint.checkpointSpawnPosition.position;
        ChangePlayerActiveState(true);
        Destroy(particleSys);
    }

    void ChangePlayerActiveState(bool isActive)
    {
        PlayerMovement playerController = gameObject.GetComponent<PlayerMovement>();
        SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        playerController.enabled = isActive;
        gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        spriteRenderer.enabled = isActive;
    }
}
