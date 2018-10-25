using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spring : MonoBehaviour {

    private Rigidbody2D colRb;        
    [SerializeField] GameObject ballGO;
    [SerializeField] float bounceForce = 30f;
    private float colAngle;
    private Collision2D springCollision2D;



    

    void OnCollisionEnter2D(Collision2D other)
    {        
        if (other.gameObject.CompareTag("Ball"))
        {
            colAngle = Vector2.Angle(other.contacts[0].normal, new Vector2(this.transform.up.x, this.transform.up.y));          
            colRb = other.gameObject.GetComponent<Rigidbody2D>();
            if (colAngle > 120)
                colRb.AddForce(this.transform.up * bounceForce, ForceMode2D.Impulse);
        }
    }

   
}
