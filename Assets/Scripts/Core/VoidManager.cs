using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoidManager : MonoBehaviour
{
    [SerializeField] List<GameObject> voidObjects = new List<GameObject>();


    

    private void Awake()
    {
        GameObject[] tempVoids = GameObject.FindGameObjectsWithTag("Void");

    }

    private void Start()
    {
        foreach(GameObject voidObject in voidObjects)
        {
            Debug.Log(voidObject.name);
        }

    }
}
