using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoidManager : MonoBehaviour
{

    [Header("Keybind")]
    [SerializeField] KeyCode ManipulateObjectKey = KeyCode.Tab;
    [SerializeField] string voidObjectTag = null;

    [SerializeField] List<GameObject> voidObjects = new List<GameObject>();



    private void Start()
    {
        foreach(GameObject voidObject in GameObject.FindGameObjectsWithTag(voidObjectTag))
        {
            voidObjects.Add(voidObject);
        }
    }

    private void Update()
    {
        DeActivateVoids();
    }

    private void DeActivateVoids()
    {
        if (Input.GetKeyDown(ManipulateObjectKey))
        {
            foreach (GameObject voidObject in voidObjects)
            {
                ChangeObjectActiveState(voidObject, false);
            }
        }
        else if (Input.GetKeyUp(ManipulateObjectKey))
        {
            foreach (GameObject voidObject in voidObjects)
            {
                ChangeObjectActiveState(voidObject, true);
            }
        }
    }

    private void ChangeObjectActiveState(GameObject voidObj, bool isActive)
    {
        voidObj.SetActive(isActive);
    }

}
