using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spring : MonoBehaviour {

    private Rigidbody2D colRb;
    [SerializeField] float bounceForce = 30f;

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            colRb = other.gameObject.GetComponent<Rigidbody2D>();
            colRb.AddForce(Vector2.up * bounceForce, ForceMode2D.Impulse);
        }
    }

   
}
