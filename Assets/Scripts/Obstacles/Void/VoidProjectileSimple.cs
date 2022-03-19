/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoidProjectileSimple : MonoBehaviour
{

    [SerializeField] float timer = 1;
    [SerializeField] int damage;
    [SerializeField] public Vector2 lastPosition;
    VoidHandler voidHandler;

    private void OnEnable()
    {
        voidHandler = FindObjectOfType<VoidHandler>();
        voidHandler.voidObjectsInScene.Add(gameObject);
    }
    private void OnDestroy()
    {
        voidHandler.voidObjectsInScene.Remove(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ground"))
        {
            Destroy(gameObject);
            return;
        }
        if(other.CompareTag("Player"))
        {
            other.GetComponent<Player>().TakeDamage();
            Destroy(gameObject);
        }
    }
}
*/
