using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] int startingPoint;
    [SerializeField] List<Transform> points = new List<Transform>();

    private int i;
    private void Start()
    {
        transform.position = points[startingPoint].position;
        i = startingPoint;
    }

    private void Update()
    {
        if (Vector2.Distance(transform.position, points[i].position) <= 0.02f)
        {
            i++;
            if(i >= (points.Count))
            {
                i = startingPoint;
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, points[i].position, speed * Time.deltaTime);
    }


    //FIX WITH ALTERNATIVE
    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.transform.SetParent(transform);
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        collision.transform.SetParent(null);
    }


}
