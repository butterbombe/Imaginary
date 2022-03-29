using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    [SerializeField] float fallTime = 3f;

    Rigidbody2D rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.tag != "Player") return;
        StartCoroutine(FallAndDisable());
    }

    IEnumerator FallAndDisable()
    {
        rb.isKinematic = false;
        yield return new WaitForSeconds(fallTime);
        Destroy(gameObject);
    }

}
