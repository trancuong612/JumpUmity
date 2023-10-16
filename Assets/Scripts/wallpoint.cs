using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallpoint : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;
    private int index_point = 0;

    [SerializeField] private float speed = 2f;

    private void Update()
    {
        if (Vector2.Distance(waypoints[index_point].transform.position, transform.position) < .1f)
        {
            index_point++;
            if(index_point >=waypoints.Length)
            {
                index_point = 0;
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, waypoints[index_point].transform.position, Time.deltaTime * speed);
    }
}
