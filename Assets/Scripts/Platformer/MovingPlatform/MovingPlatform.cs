using System.Collections;
using NUnit.Framework.Internal;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    [SerializeField] private Transform[] points;

    private int currentIndex = 0;

    private void Start()
    {
        if (points.Length > 0)
            transform.position = points[0].position;
    }

    private void Update()
    {
        if (points == null || points.Length < 2) return;

        Transform target = points[currentIndex];

        transform.position = Vector2.MoveTowards(
            transform.position,
            target.position,
            speed * Time.deltaTime
        );

        if (Vector2.Distance(transform.position, target.position) < 0.05f)
        {
            currentIndex++;

            if (currentIndex >= points.Length)
                currentIndex = 0;
        }
    }
   

}
