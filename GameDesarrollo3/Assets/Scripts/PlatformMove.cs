using UnityEngine;
using System.Collections;
using System;

public class PlatformMove: MonoBehaviour
{
    [SerializeField] private Transform[] waypoints;
    [SerializeField] private float speed;
    [SerializeField] private bool loop;
    [SerializeField] private int timesRepeat;
    [SerializeField] private bool moveWhenPlayer;
    public bool activate = false;
    private Vector2 originalPosition;
    private Rigidbody2D rb2d;
    private Vector3 nextPoint = Vector2.zero;
    private Vector3 moveVector = Vector2.zero;
    private int nextWaypointIndex = 0;
    private bool ballCollide = false;

    void Awake()
    {
        originalPosition = this.transform.position;

        if (waypoints.Length > 0)
        {
            transform.position = waypoints[0].position;
            CalculateNextWaypoint();
        }        
    }    

    void LateUpdate()
    {
        //Debug.Log("BALLCOLLIDE bool = " + ballCollide);
        //Debug.Log(this.name + " - nextwayp = " + nextWaypointIndex);
        if (moveWhenPlayer == true)
        {
            if (activate == true)             
                Move();            
        }
        else
            Move();
        
        
    }

    private void CalculateNextWaypoint() {

        nextWaypointIndex++;
        if (nextWaypointIndex == waypoints.Length)        
            nextWaypointIndex = 0;
           
        
        nextPoint = waypoints[nextWaypointIndex].position;

        moveVector = nextPoint - transform.position;
        moveVector.Normalize();
    }

    private void Move()
    {
        //PLATAFORMAS
        if (this.gameObject.layer==8)
        {
            if (moveWhenPlayer == true)
            {
                if (Vector3.Distance(transform.position, waypoints[0].position) < 0.5f && !ballCollide)
                {
                    transform.position = waypoints[0].position;
                    activate = false;
                }
            }

            transform.Translate(moveVector * speed * Time.deltaTime, Space.World);

            if (Vector3.Distance(transform.position, nextPoint) < 0.5f)
            {
                CalculateNextWaypoint();
            }
        }
        //ENEMIGOS
        if (this.gameObject.layer == 14)
        {            
            transform.Translate(moveVector * speed * Time.deltaTime, Space.World);
            if (Vector3.Distance(transform.position, nextPoint) < 0.5f)
            {
                CalculateNextWaypoint();
            }
        }


    }

    public void ResetPosition()
    {        
        this.transform.position = originalPosition;
        nextWaypointIndex = 0;
        nextPoint = Vector2.zero;
        moveVector = Vector2.zero;
        CalculateNextWaypoint();
        this.activate = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {        
        if(collision.gameObject.tag == "Ball")
        {
            Debug.Log("ACTIVATE");
            ballCollide = true;
        }
       
    }
    
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            Debug.Log("DE-ACTIVATE");
            ballCollide = false;
        }
    }

}