using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class ActivatorButton : MonoBehaviour
{
    [SerializeField] UnityEvent buttonPressed;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            buttonPressed.Invoke();
            gameObject.SetActive(false);
        }
    }
}
