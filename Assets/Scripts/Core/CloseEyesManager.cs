using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseEyesManager : MonoBehaviour
{

    [Header("Keybind")]
    [SerializeField] public KeyCode ManipulateObjectKey = KeyCode.Tab;
    [SerializeField] string voidObjectTag = null;
    [SerializeField] string sparkObjectTag = null;

    [SerializeField] List<GameObject> voidObjects = new List<GameObject>();
    [SerializeField] List<GameObject> sparkObjects = new List<GameObject>();



    private void Awake()
    {
        foreach(GameObject voidObject in GameObject.FindGameObjectsWithTag(voidObjectTag))
        {
            voidObjects.Add(voidObject);
        }
        foreach (GameObject voidObject in GameObject.FindGameObjectsWithTag(sparkObjectTag))
        {
            voidObjects.Add(voidObject);
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(ManipulateObjectKey))
        {
            CloseEyes();
        }
        if (Input.GetKeyUp(ManipulateObjectKey))
        {
            OpenEyes();
        }
    }

    private void CloseEyes()
    {
        foreach (GameObject voidObject in voidObjects)
        {

            voidObject.GetComponent<ObjectFader>().FadeIn();
        }

        foreach (GameObject sparkObject in sparkObjects)
        {
            //ChangeObjectActiveState(sparkObject, true);
        }
    }
    private void OpenEyes()
    {
        
        foreach (GameObject voidObject in voidObjects)
        {

            voidObject.GetComponent<ObjectFader>().FadeOut();
        }

        foreach (GameObject sparkObject in sparkObjects)
        {
            //ChangeObjectActiveState(sparkObject, false);
        }
    }


}
