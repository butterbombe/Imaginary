using System.Collections.Generic;
using UnityEngine;

public class CloseEyesManager : MonoBehaviour
{

    [Header("Keybind")]
    [SerializeField] public KeyCode ManipulateObjectKey = KeyCode.Tab;
    [SerializeField] string voidObjectTag = null;
    [SerializeField] string sparkObjectTag = null;
    [SerializeField] string voidParticleTag = null;
    [SerializeField] string sparkParticleTag = null;

    [SerializeField] List<GameObject> voidObjects = new List<GameObject>();
    [SerializeField] List<GameObject> sparkObjects = new List<GameObject>();
    [SerializeField] List<GameObject> voidParticles = new List<GameObject>();
    [SerializeField] List<GameObject> sparkParticles = new List<GameObject>();

    private Animator eyesAnimator;


    private void Awake()
    {
        eyesAnimator = FindObjectOfType<Eyes>().gameObject.GetComponent<Animator>();
        
        foreach(GameObject voidObject in GameObject.FindGameObjectsWithTag(voidObjectTag))
        {
            voidObjects.Add(voidObject);
        }
        foreach (GameObject sparkObject in GameObject.FindGameObjectsWithTag(sparkObjectTag))
        {
            sparkObjects.Add(sparkObject);
        }
        foreach (GameObject voidParticle in GameObject.FindGameObjectsWithTag(voidParticleTag))
        {
            voidParticles.Add(voidParticle);
        }
        foreach (GameObject sparkParticle in GameObject.FindGameObjectsWithTag(sparkParticleTag))
        {
            sparkParticles.Add(sparkParticle);
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

        //foreach (GameObject sparkObject in sparkObjects)
        //{
        //    //ChangeObjectActiveState(sparkObject, true);
        //}

        foreach (GameObject voidParticle in voidParticles)
        {
            voidParticle.GetComponent<ParticleFader>().FadeIn();
        }

        //foreach (GameObject sparkParticle in sparkParticles)
        //{
        //    sparkParticle.GetComponent<ParticleFader>().FadeIn();
        //}
    }
    private void OpenEyes()
    {
        eyesAnimator.SetTrigger("OpenEyes");
        foreach (GameObject voidObject in voidObjects)
        {

            voidObject.GetComponent<ObjectFader>().FadeOut();
        }

        foreach (GameObject voidParticle in voidParticles)
        {
            voidParticle.GetComponent<ParticleFader>().FadeOut();
        }

        //foreach (GameObject sparkObject in sparkObjects)
        //{
        //    //ChangeObjectActiveState(sparkObject, false);
        //}
    }


}
