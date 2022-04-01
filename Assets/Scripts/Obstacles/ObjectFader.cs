using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectFader : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    private void Awake()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }
    private void LateUpdate()
    {
        if (spriteRenderer.color.a > 0)
        {
            ChangeObjectActiveState(gameObject, true);
        }
        else
        {
            ChangeObjectActiveState(gameObject, false);
        }
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
    private void ChangeObjectActiveState(GameObject gameObj, bool isActive)
    {
        gameObj.GetComponent<Collider2D>().enabled = isActive;
    }

    public IEnumerator FadeInCoroutine()
    {

        float alphaVal = spriteRenderer.color.a;
        Color tmp = spriteRenderer.color;
        while (spriteRenderer.color.a > 0)
        {
            alphaVal -= 0.05f;
            tmp.a = alphaVal;
            spriteRenderer.color = tmp;

            yield return new WaitForSeconds(0.02f); // update interval
        }
    }

    public IEnumerator FadeOutCoroutine()
    {

        float alphaVal = spriteRenderer.color.a;
        Color tmp = spriteRenderer.color;
        while (spriteRenderer.color.a < 1)
        {
            alphaVal += 0.1f;
            tmp.a = alphaVal;
            spriteRenderer.color = tmp;

            yield return new WaitForSeconds(0.05f); // update interval
        }
    }
}
