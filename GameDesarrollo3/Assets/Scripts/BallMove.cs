using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMove : MonoBehaviour{

    public float jumpForce = 250.0f;   
    private Rigidbody2D rb;
    public float moveSpeed = 100.0f;    

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();       
    }

    void Update()
    {
        Debug.Log(rb.IsTouchingLayers(LayerMask.NameToLayer("Platforms")));
        if(InputManager.Instance.GetJumpButton() == true && rb.IsTouchingLayers(LayerMask.NameToLayer("Platforms")))
        {
            Debug.Log("ifSalto");
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

        
}

    private void FixedUpdate()
    {
		//movimiento izq-derecha
		this.transform.rotation = Quaternion.identity;
        rb.AddForce(Vector2.right * InputManager.Instance.GetHorizontalAxis() * moveSpeed * Time.deltaTime, ForceMode2D.Impulse);

        //salto
       
	}
}


