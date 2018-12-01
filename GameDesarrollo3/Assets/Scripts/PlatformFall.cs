using UnityEngine;
using System.Collections;

public class PlatformFall : MonoBehaviour
{

    public float fallDelay = 1f;
    public float DisableColliderDelay = 3f;
    private Rigidbody2D rb2d;
    private Collider2D col2d;
    private Vector2 originalPosition;
    [SerializeField] float _timeToReset;

    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        col2d = GetComponent<Collider2D>();
        originalPosition = this.transform.position;        
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ball"))
            Invoke("Fall", fallDelay);
        //else            
            //this.gameObject.SetActive(false);        
    }    

    void Fall()
    {
        rb2d.bodyType = RigidbodyType2D.Dynamic;
        this.transform.DetachChildren();
        //this.gameObject.SetActive(false);
        this.gameObject.GetComponent<Collider2D>().enabled = false;
        this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        StartCoroutine(ExecuteAfterTime(_timeToReset));
    }

    public void ResetPosition()
    {
        CancelInvoke();
        //this.gameObject.SetActive(true);
        this.gameObject.GetComponent<Collider2D>().enabled = true;
        this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
        rb2d.velocity = Vector2.zero;
        rb2d.bodyType = RigidbodyType2D.Kinematic;
        this.transform.position = originalPosition;        
    }

    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);

        // Code to execute after the delay

        ResetPosition();
    }
}