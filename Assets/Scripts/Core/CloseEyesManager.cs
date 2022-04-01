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

    private Animator eyesAnimator;


    private void Awake()
    {
        eyesAnimator = FindObjectOfType<Eyes>().gameObject.GetComponent<Animator>();
        
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
        eyesAnimator.SetTrigger("CloseEyes");
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
        eyesAnimator.SetTrigger("OpenEyes");
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
