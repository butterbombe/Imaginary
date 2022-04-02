using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleFader : MonoBehaviour
{
    ParticleSystem.MainModule particleSys;

    private void Awake()
    {
        particleSys = gameObject.GetComponent<ParticleSystem>().main;
    }

    public void FadeIn()
    {
        StopAllCoroutines();
        StartCoroutine(FadeInCoroutine());

    }
    public void FadeOut()
    {
        StopAllCoroutines();
        StartCoroutine(FadeOutCoroutine());
        
    }

    public IEnumerator FadeInCoroutine()
    {

        float alphaVal = particleSys.startColor.color.a;
        Color tmp = particleSys.startColor.color;
        while (particleSys.startColor.color.a > 0)
        {
            alphaVal -= 0.1f;
            tmp.a = alphaVal;
            particleSys.startColor = tmp;

            yield return new WaitForSeconds(0.02f); // update interval
        }
    }

    public IEnumerator FadeOutCoroutine()
    {

        float alphaVal = particleSys.startColor.color.a;
        Color tmp = particleSys.startColor.color;
        while (particleSys.startColor.color.a < 1)
        {
            alphaVal += 0.1f;
            tmp.a = alphaVal;
            particleSys.startColor = tmp;

            yield return new WaitForSeconds(0.02f); // update interval
        }
    }
}
