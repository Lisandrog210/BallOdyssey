using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMove : MonoBehaviour {

    [SerializeField] private float jumpForce = 24.0f;   
    private Rigidbody2D rb;    
    [SerializeField] private float moveSpeed = 19.0f;
    private bool isGrounded;
    public static BallMove instance;
    private bool moving;    

    public static BallMove Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<BallMove>();
            }
            return instance;
        }
    }

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();        
        instance = this;
    }

    void Update()
    {        

        //SALTO--------------solo cuando esta en la plataf--------------------------------------------------------------- 
        if (InputManager.Instance.GetJumpButton() == true && isGrounded==true)
        {

            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            //Debug.Log(isGrounded);
        }

        
    }

    private void FixedUpdate()
    {
		//MOVIMIENTO izq-derecha// Si esta en el aire el movimiento es ínfimo----------------------
		this.transform.rotation = Quaternion.identity;

        if(isGrounded == true)
        {
            rb.AddForce(Vector2.right * InputManager.Instance.GetHorizontalAxis() * moveSpeed * Time.deltaTime, ForceMode2D.Impulse);
        }
        else
        {
            rb.AddForce(Vector2.right * InputManager.Instance.GetHorizontalAxis() * moveSpeed / 3 * Time.deltaTime, ForceMode2D.Impulse);
        }
    }

   
    void OnCollisionEnter2D(Collision2D collision) 
    {
        if(collision.collider.gameObject.layer == LayerMask.NameToLayer("Platforms")|| collision.collider.gameObject.layer == LayerMask.NameToLayer("FallingPlatforms")) 
        {
            isGrounded = true;
            this.transform.SetParent(collision.transform);
        }
        if (collision.collider.gameObject.tag == "FastPlatform")
        {            
            rb.AddForce(Vector2.right * moveSpeed*1f, ForceMode2D.Impulse);
        }
        if (collision.collider.gameObject.tag == "FastPlatformx2")
        {            
            rb.AddForce(Vector2.right * moveSpeed * 8f, ForceMode2D.Impulse);
        }
        if(collision.collider.gameObject.tag == "MovingPlatform")
        {
            FrictionJoint2D rb2d = collision.gameObject.GetComponent<FrictionJoint2D>();
            rb2d.connectedBody = rb;            
        }
    }

    void OnCollisionExit2D(Collision2D collision) 
    {

        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Platforms") || collision.collider.gameObject.layer == LayerMask.NameToLayer("FallingPlatforms"))
        {
            isGrounded = false;
            Debug.Log(isGrounded+" -- " +collision.collider.name);
            this.transform.SetParent(null);
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {

        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Platforms") || collision.collider.gameObject.layer == LayerMask.NameToLayer("FallingPlatforms"))
        {
            isGrounded = true;
            Debug.Log(isGrounded + " -- " + collision.collider.name);
            this.transform.SetParent(collision.transform);
        }
        
    }
}


