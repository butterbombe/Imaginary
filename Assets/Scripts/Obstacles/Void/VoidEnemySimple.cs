using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoidEnemySimple : MonoBehaviour
{
    [Header("Projectile")]
    [SerializeField] float shootDelay;
                     float shotTimer;
    [SerializeField] float projectileSpeed;
    [SerializeField] GameObject projectile;
    [SerializeField] Transform gunpoint;
    [SerializeField] Vector2 direction;
    [Header("Headjump")]
    [SerializeField] Transform overlapArea1;
    [SerializeField] Transform overlapArea2;
    [SerializeField] int playerLayer;
    [Header("Misc")]
    [SerializeField] VoidHandler voidHandler;


    private void Start()
    {
        shotTimer = shootDelay;
    }

    private void Update()
    {
        CheckHeadBob();

        if (voidHandler.eyesClosed)
        {
            return;
        }
        if (shotTimer <= 0)
        {
            //do stuff

            shotTimer = shootDelay;
            GameObject p = Instantiate(projectile, gunpoint.position, Quaternion.identity);
            p.GetComponent<Rigidbody2D>().AddForce(direction * projectileSpeed, ForceMode2D.Impulse);
        }
        else
        {
            shotTimer -= Time.deltaTime;
        }
    }

    public void CheckHeadBob()
    {
        bool hitbyPlayer = Physics2D.OverlapArea(overlapArea1.position, overlapArea1.position, playerLayer);
        if(!hitbyPlayer)
        {
            return;
        }
        Debug.Log("hit enemy");
    }
}
