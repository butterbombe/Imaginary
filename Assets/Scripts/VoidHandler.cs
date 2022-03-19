using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class VoidHandler : MonoBehaviour
{
    [SerializeField] string voidTag;
    [SerializeField] Tilemap voidTilemap;
    [SerializeField] Tilemap sparklyTilemap;
    [SerializeField] public bool eyesClosed = false;
    [SerializeField] public List<GameObject> voidObjectsInScene = new List<GameObject>();


    private void LateUpdate()
    {
        foreach(GameObject voidObject in GameObject.FindGameObjectsWithTag(voidTag))
        {
            if(voidObjectsInScene.Contains(voidObject))
            {
                return;
            }
            voidObjectsInScene.Add(voidObject);
        }

    }
    private void Start()
    {
        sparklyTilemap.GetComponent<TilemapRenderer>().enabled = false;
        sparklyTilemap.GetComponent<TilemapCollider2D>().enabled = false;
    }

    public void DisableVoids()
    {
        #region code
        //GAMEOBJECTS
        eyesClosed = true;
        foreach (GameObject voidObject in voidObjectsInScene)
        {
            if (!voidObject.GetComponent<SpriteRenderer>().enabled)
            {
                return;
            }
            if (voidObject.layer == 9)
            {
                voidObject.GetComponent<VoidProjectileSimple>().lastPosition = voidObject.transform.position;
            }
            voidObject.GetComponent<SpriteRenderer>().enabled = false;
            voidObject.GetComponent<Collider2D>().enabled = false;
        }
        //TILEMAPS
        if (!voidTilemap.GetComponent<TilemapRenderer>().enabled)
        {
            return;
        }
        else
        {
            voidTilemap.GetComponent<TilemapRenderer>().enabled = false;
            voidTilemap.GetComponent<TilemapCollider2D>().enabled = false;
        }
        //REVERSE
        if (sparklyTilemap.GetComponent<TilemapRenderer>().enabled)
        {
            return;
        }
        else
        {
            sparklyTilemap.GetComponent<TilemapRenderer>().enabled = true;
            sparklyTilemap.GetComponent<TilemapCollider2D>().enabled = true;
        }
        #endregion
        #region fullActive
        //eyesClosed = true;
        //foreach (GameObject voidObject in voidObjectsInScene)
        //{
        //    if(!voidObject.activeSelf)
        //    {
        //        return;
        //    }
        //    voidObject.SetActive(false);
        //}
        //if(!voidTilemap.enabled)
        //{
        //    return;
        //}
        //else
        //{
        //    voidTilemap.enabled = false;
        //}
        #endregion
    }

    public void EnableVoids()
    {
        #region code
        //GAMEOBJECTS
        eyesClosed = false;
        foreach (GameObject voidObject in voidObjectsInScene)
        {
            if (voidObject.GetComponent<SpriteRenderer>().enabled)
            {
                return;
            }
            if (voidObject.layer == 9)
            {
                voidObject.transform.position = voidObject.GetComponent<VoidProjectileSimple>().lastPosition;
            }

            voidObject.GetComponent<SpriteRenderer>().enabled = true;
            voidObject.GetComponent<Collider2D>().enabled = true;
        }
        //TILEMAPS
        if (voidTilemap.GetComponent<TilemapRenderer>().enabled)
        {
            return;
        }
        else
        {
            voidTilemap.GetComponent<TilemapRenderer>().enabled = true;
            voidTilemap.GetComponent<TilemapCollider2D>().enabled = true;
        }
        //REVERSE
        if (!sparklyTilemap.GetComponent<TilemapRenderer>().enabled)
        {
            return;
        }
        else
        {
            sparklyTilemap.GetComponent<TilemapRenderer>().enabled = false;
            sparklyTilemap.GetComponent<TilemapCollider2D>().enabled = false;
        }
        #endregion
        #region fullActive
        //eyesClosed = false;
        //foreach (GameObject voidObject in voidObjectsInScene)
        //{
        //    if (voidObject.activeSelf)
        //    {
        //        return;
        //    }
        //    voidObject.SetActive(true);
        //}
        //if (voidTilemap.enabled)
        //{
        //    return;
        //}
        //else
        //{
        //    voidTilemap.enabled = true;
        //}
        #endregion
    }
}
