using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMove : MonoBehaviour{
    
    Vector2 mov;

    Rigidbody2D rb;
    
    [SerializeField] float speed;
    

    void Awake()
    {
        //rb = GetComponent<Rigidbody2D>();

    }

    void Update()
    {
       // mov.x = Input.GetAxis("Horizontal");
        transform.Translate(Input.acceleration.x, 0, -Input.acceleration.x);
        
    }

    private void FixedUpdate()
    {
        //transform.Translate(Input.acceleration.x,0,-Input.acceleration.x);
    }
}

