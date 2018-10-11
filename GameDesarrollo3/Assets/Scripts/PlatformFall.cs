using UnityEngine;
using System.Collections;

public class PlatformFall : MonoBehaviour
{

    public float fallDelay = 1f;


    private Rigidbody2D rb2d;
    private Collider2D col2d;
    private Vector2 originalPosition;

    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        col2d = GetComponent<Collider2D>();
        originalPosition = this.transform.position;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            Invoke("Fall", fallDelay);
        }
    }
    

    void Fall()
    {
        rb2d.bodyType = RigidbodyType2D.Dynamic;
        col2d.enabled = false;        
    }

    public void ResetPosition()
    {
        Debug.Log("RESET PLATFORM");
        rb2d.velocity = Vector2.zero;
        rb2d.bodyType = RigidbodyType2D.Kinematic;
        this.transform.position = originalPosition;
        col2d.enabled = true;
    }



}