using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMove : MonoBehaviour{

   
    private Rigidbody2D rb;
    public float moveSpeed = 0.5f;
    public float fallingSpeed = 5f;
    
    
    

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
       
    }

    void Update()
    {

        rb.velocity = new Vector2(Input.acceleration.x*moveSpeed, fallingSpeed);
        this.transform.rotation = Quaternion.identity;


    }

    private void FixedUpdate()
    {
        
    }
}

