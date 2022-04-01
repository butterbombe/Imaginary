using System.Collections;
using UnityEngine;

public class WaterCollision : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<PlayerCheckpoint>().ResetToLastCheckpoint();
        }
    }
}
