using UnityEngine;
using System.Collections;
using System;

public class TrapMove : MonoBehaviour
{
    [SerializeField] private Transform[] waypoints;
    [SerializeField] private float speed;
    [SerializeField] private bool loop;
    [SerializeField] private int timesRepeat;
    [SerializeField] private float wait;


    private Vector3 nextPoint = Vector2.zero;
    private Vector3 moveVector = Vector2.zero;
    private int nextWaypointIndex = 0;

    void Start()
    {
        if (waypoints.Length > 0)
        {
            transform.position = waypoints[0].position;

            CalculateNextWaypoint();
        }
        StartCoroutine(WaitTime());
    }

    void Update()
    {
        //Debug.Log(moveVector);
        Move();
    }

    private void CalculateNextWaypoint()
    {

        nextWaypointIndex++;
        if (nextWaypointIndex == waypoints.Length)
            nextWaypointIndex = 0;

        nextPoint = waypoints[nextWaypointIndex].position;

        moveVector = nextPoint - transform.position;
        moveVector.Normalize();
    }

    private void Move()
    {
        transform.Translate(moveVector * speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, nextPoint) < 0.5f)
        {
            CalculateNextWaypoint();
        }
    }

    IEnumerator WaitTime()
    {
        yield return new WaitForSeconds(wait);
    }
}