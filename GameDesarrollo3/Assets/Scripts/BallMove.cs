﻿using System.Collections;
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

        


    }

    private void FixedUpdate()
    {
		//rb.velocity = new Vector2(Input.acceleration.x * moveSpeed, fallingSpeed);
		rb.AddForce(Vector2.right * Input.acceleration.x * moveSpeed,ForceMode2D.Impulse);
		this.transform.rotation = Quaternion.identity;
	}
}

