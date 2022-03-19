using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eyefollow : MonoBehaviour
{
    GameObject player;
    void Start()
    {
        player = GameObject.Find("Player");
    }
    void Update()
    {
        FollowPlayer();
    }

    void FollowPlayer()
    {
        Vector3 playerpos = player.transform.position;

        Vector2 direction = new Vector2(playerpos.x - transform.position.x, playerpos.y - transform.position.y);
        transform.up = direction;
    }
}
