using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMove : MonoBehaviour
{
    [SerializeField] private float jumpForce = 24.0f;
    private Rigidbody2D rb;
    [SerializeField] private float moveSpeed = 0.038f;
    private bool isGrounded;
    public static BallMove instance;
    private bool moving;
    private float colAngle;
    private float numberOfBounces;
    private float hAxis = 0.0f;
    private float maxSpeedGround = 20;
    private float maxSpeedAir = 20;
    public bool jumpAvailable;
    Vector2 lastContactPos = new Vector2();
    GameObject pausePanel;

    [SerializeField] AudioClip jumpSound;
    [SerializeField] AudioClip groundSound;
    [SerializeField] AudioClip impulseSound;
    [SerializeField] AudioClip springSound;

    AudioSource audioS;

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
        jumpAvailable = true;
        rb = GetComponent<Rigidbody2D>();
        instance = this;
        numberOfBounces = 1;              
        pausePanel = GameObject.FindGameObjectWithTag("PausePanel");
        audioS = GetComponent<AudioSource>();        
    }

    void Update()
    {
        
        hAxis = InputManager.Instance.GetHorizontalAxis();

        //----------------------------------------------- SALTO -------------------------------------------------------------------------------
        if (InputManager.Instance.GetJumpButton() == true &&
            /*isGrounded == true*/  jumpAvailable == true &&
            !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
        {           
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            jumpAvailable = false;
            audioS.PlayOneShot(jumpSound, 1F);
            //this.transform.SetParent(null);
        }
    }

    private void OnApplicationPause(bool pause)
    {
        if (pause)
        {
            Debug.Log("On application pause");
            pausePanel.SetActive(true);
            Time.timeScale = 0;
        }
    }

    private void FixedUpdate()
    {
        //Debug.Log("max speed ground = " + maxSpeedGround);
        //Debug.Log("max speed air = " + maxSpeedAir);

        //MOVIMIENTO izq-derecha// Si esta en el aire el movimiento es ínfimo----------------------
        this.transform.rotation = Quaternion.identity;
        //Debug.Log("IS GROUNDED? - " + isGrounded);
        Debug.Log("Velocity = " + rb.velocity);
        //Debug.Log("IS GROUNDED = " + isGrounded);
        if (isGrounded == true)
        {
            rb.AddForce(Vector2.right * hAxis * moveSpeed, ForceMode2D.Impulse);
        }
        else
        {
            rb.AddForce(Vector2.right * hAxis * moveSpeed  * .2f, ForceMode2D.Impulse);            
        }
        
        Vector3 vel = rb.velocity;
        if (vel.magnitude > maxSpeedAir && !isGrounded)
        {
            rb.velocity = vel.normalized * maxSpeedAir;
        }
        else if (vel.magnitude > maxSpeedGround && isGrounded)
        {
            rb.velocity = vel.normalized * maxSpeedGround;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {        
        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Platforms"))
        {
            //isGrounded = true;
            this.transform.SetParent(collision.transform);
            numberOfBounces = 1;
            jumpAvailable = true;
            audioS.PlayOneShot(groundSound, 1F);
            //lastContactPos = collision.contacts[0].point;
        }
        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("FallingPlatforms"))
        {
            //isGrounded = true;
            numberOfBounces = 1;
            jumpAvailable = true;
            audioS.PlayOneShot(groundSound, 1F);
            //lastContactPos = collision.contacts[0].point;
        }
        if (collision.collider.gameObject.tag == "FastPlatform")
        {
            maxSpeedAir = 100;
            maxSpeedGround = 100;
            rb.AddForce(Vector2.right * moveSpeed * 50f, ForceMode2D.Impulse);
            numberOfBounces = 1;
            jumpAvailable = true;
            audioS.PlayOneShot(impulseSound, 1F);
            //lastContactPos = collision.contacts[0].point;
        }
        if (collision.collider.gameObject.tag == "FastPlatformx2")
        {
            rb.AddForce(Vector2.right * moveSpeed * 8f, ForceMode2D.Impulse);
            numberOfBounces = 1;
            jumpAvailable = true;
            audioS.PlayOneShot(impulseSound, 1F);
            //lastContactPos = collision.contacts[0].point;
        }
        if (collision.collider.gameObject.tag == "MovingPlatform")
        {
            FrictionJoint2D rb2d = collision.gameObject.GetComponent<FrictionJoint2D>();
            numberOfBounces = 1;
            rb2d.connectedBody = rb;
            collision.gameObject.GetComponent<PlatformMove>().activate = true;
            jumpAvailable = true;
            audioS.PlayOneShot(groundSound, 1F);
            //lastContactPos = collision.contacts[0].point;
        }
        if (collision.collider.gameObject.tag == "SmallPlatform")
        {
            FrictionJoint2D rb2d = collision.gameObject.GetComponent<FrictionJoint2D>();
            numberOfBounces = 1;
            rb2d.connectedBody = rb;
            jumpAvailable = true;
            audioS.PlayOneShot(groundSound, 1F);
            //lastContactPos = collision.contacts[0].point;
        }
        if (collision.gameObject.CompareTag("Spring"))
        {

            audioS.PlayOneShot(springSound, 1F);
            colAngle = Vector2.Angle(-collision.contacts[0].normal, new Vector2(collision.transform.up.x, collision.transform.up.y));
            if (colAngle > 120)
            {
                numberOfBounces += 0.1f;
                rb.AddForce((transform.up * 35) * numberOfBounces, ForceMode2D.Impulse);
            }
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        //Debug.Log(isGrounded + " -- " + collision.collider.name);
        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Platforms") || 
            collision.collider.gameObject.layer == LayerMask.NameToLayer("FastPlatforms"))
        {
            maxSpeedAir = 20;
            maxSpeedGround = 13;
            jumpAvailable = false;
            isGrounded = false;
            //Debug.Log(isGrounded+" -- " +collision.collider.name);
            if(this.gameObject.activeSelf)
                this.transform.SetParent(null);
            /*Vector2 aux = new Vector2();
            aux.x = this.transform.position.x;
            aux.y = this.transform.position.y;            
            Debug.Log("herhe" + Vector2.Distance(aux, lastContactPos));
            if (Vector2.Distance(aux, lastContactPos) > 1.25f)
            {
                Debug.Log("herhe" + Vector2.Distance(aux, lastContactPos));
                Debug.Log("Bola sale del padre, fue intencional?");
                //this.transform.SetParent(null);                
            }*/

        }
        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("FallingPlatforms"))
        {
            isGrounded = false;
        }
        if (collision.collider.gameObject.tag == "MovingPlatform")
        {
            FrictionJoint2D rb2d = collision.gameObject.GetComponent<FrictionJoint2D>();
            rb2d.connectedBody = null;
            //collision.gameObject.GetComponent<PlatformMove>().activate = true;
        }
        if (collision.collider.gameObject.tag == "SmallPlatform")
        {
            FrictionJoint2D rb2d = collision.gameObject.GetComponent<FrictionJoint2D>();
            rb2d.connectedBody = null;
        }
        if (collision.collider.gameObject.tag == "Spring")
        {
            isGrounded = false;
            maxSpeedAir = 40;
            maxSpeedGround = 40;
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {        
        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Platforms") || 
            collision.collider.gameObject.layer == LayerMask.NameToLayer("FallingPlatforms"))
        {
            maxSpeedAir = 20;
            maxSpeedGround = 13;
            isGrounded = true;
           //Debug.Log(isGrounded + " -- " + collision.collider.name);
            //this.transform.SetParent(collision.transform); ---- esto esta repetido en collision enter por eso lo comento
            //lastContactPos = collision.contacts[0].point;
        }
    }
}


