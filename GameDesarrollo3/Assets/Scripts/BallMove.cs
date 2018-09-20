using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMove : MonoBehaviour{

    public float jumpForce = 250.0f;   
    private Rigidbody2D rb;    
    public float moveSpeed = 100.0f;
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
            Debug.Log("ifSalto");
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
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
            rb.AddForce(Vector2.right * InputManager.Instance.GetHorizontalAxis() * moveSpeed / 10 * Time.deltaTime, ForceMode2D.Impulse);
        }
            

    }

   
    void OnCollisionEnter2D(Collision2D collision) 
    {
        if(collision.collider.gameObject.layer == LayerMask.NameToLayer("Platforms")) 
        {
            isGrounded = true;
            this.transform.SetParent(collision.transform);
            
        }
        
    }

    void OnCollisionExit2D(Collision2D collision) 
    {
        isGrounded = false;        
    }
}


