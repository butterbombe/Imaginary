using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != "Player") return;
        StartCoroutine(LoadNextScene());
    }


    public IEnumerator LoadNextScene()
    {
        yield return SceneManager.LoadSceneAsync(FindNextScene());
    }

    int FindNextScene()
    {
        if (SceneManager.GetActiveScene().buildIndex + 1 > SceneManager.sceneCount)
        {
            return 0;
        }
        return SceneManager.GetActiveScene().buildIndex + 1;
    }



}
