using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public Transform checkpointSpawnPosition;
    [SerializeField] bool isSpawnpoint = false;

    private void Awake()
    {
        if (!isSpawnpoint) return;
        GameObject.FindWithTag("Player").GetComponent<PlayerCheckpoint>().SetCheckpoint(this);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
             collision.GetComponent<PlayerCheckpoint>().SetCheckpoint(this);
        }
    }
}
