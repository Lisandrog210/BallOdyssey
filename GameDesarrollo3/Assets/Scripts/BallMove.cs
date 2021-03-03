using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System.Linq;

public class BallMove : MonoBehaviour
{
    [SerializeField]
    private float jumpForce = 8;
    private Rigidbody2D rb;
    [SerializeField]
    private float moveSpeed = 60;
    public bool isGrounded;
    private bool isPaused = false;
    public static BallMove instance;
    private bool moving;
    private float colAngle;
    private float numberOfBounces;
    private float hAxis = 0.0f;
    private float maxSpeedGround = 14;
    private float maxSpeedAir = 14;
    public bool jumpAvailable;
    Vector2 lastContactPos = new Vector2();
    GameObject pausePanel;
    bool playHitSound;

    [SerializeField]
    AudioClip jumpSound;
    [SerializeField]
    AudioClip groundSound;
    [SerializeField]
    AudioClip impulseSound;
    [SerializeField]
    AudioClip springSound;

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
        playHitSound = false;
        jumpAvailable = true;
        rb = GetComponent<Rigidbody2D>();
        instance = this;
        numberOfBounces = 1;
        pausePanel = GameObject.FindGameObjectWithTag("PausePanel");
        audioS = GetComponent<AudioSource>();
    }

    void Update()
    {      

        //----------------------------------------------- SALTO -------------------------------------------------------------------------------

        hAxis = InputManager.Instance.GetHorizontalAxis();

        if (InputManager.Instance.GetJumpButton() == true && jumpAvailable == true && !IsPointerOverUIObject())
        {          
            Vector2 jumpvelocity = new Vector3(0.0f, jumpForce);
            rb.velocity = rb.velocity + jumpvelocity;
        }
        if (Input.GetKeyDown(KeyCode.Space) && jumpAvailable == true)
        {
            Vector2 jumpvelocity = new Vector3(0.0f, jumpForce);
            rb.velocity = rb.velocity + jumpvelocity;
        }
        Vector3 aux = this.transform.position - new Vector3(0, 0.6f, 0.0f);
        Debug.DrawRay(aux, Vector3.down, Color.blue);
        if (Physics2D.Raycast(aux, Vector3.down, 0.6f))
        {
            isGrounded = true;
            jumpAvailable = true;
            print("isgrounded");
        }
        else
        {
            playHitSound = true;
            isGrounded = false;
            jumpAvailable = false;
            print("notgrounded");
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

    private bool IsPointerOverUIObject()
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        return results.Count > 0;
    }

    private void FixedUpdate()
    {

        //MOVIMIENTO izq-derecha// Si esta en el aire el movimiento es ínfimo----------------------
        this.transform.rotation = Quaternion.identity;

        if (isGrounded == true)
        {
            rb.AddForce(Vector2.right * hAxis * moveSpeed * Time.deltaTime, ForceMode2D.Impulse);
        }
        else
        {
            rb.AddForce(Vector2.right * hAxis * moveSpeed * Time.deltaTime * .2f, ForceMode2D.Impulse);
        }

        //---------esto deberia limitar la velocidad solamente en x para no joder al salto-----
        Vector3 v = rb.velocity;
        v.x = Mathf.Clamp(v.x, -maxSpeedGround, maxSpeedGround);
        rb.velocity = v;      
    }




    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Platforms"))
        {           
            this.transform.SetParent(collision.transform);
            numberOfBounces = 1;
            if (playHitSound)
            {
                audioS.PlayOneShot(groundSound, 1F);
                playHitSound = false;
            }
                
        }
        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("FallingPlatforms"))
        {         
            numberOfBounces = 1;
            if (playHitSound)
            {
                audioS.PlayOneShot(groundSound, 1F);
                playHitSound = false;
            }          
        }       

        if (collision.collider.gameObject.tag == "FastPlatform")
        {
            maxSpeedAir = 100;
            maxSpeedGround = 100;
            rb.AddForce(Vector2.right * hAxis * moveSpeed * 10f, ForceMode2D.Impulse);
            numberOfBounces = 1;

            if (playHitSound)
            {
                audioS.PlayOneShot(impulseSound, 1F);
                playHitSound = false;
            }              
        }
        if (collision.collider.gameObject.tag == "FastPlatformx2")
        {
            rb.AddForce(Vector2.right * moveSpeed * 8f, ForceMode2D.Impulse);
            numberOfBounces = 1;
            if (playHitSound)
            {
                audioS.PlayOneShot(impulseSound, 1F);
                playHitSound = false;
            }          
        }
        if (collision.collider.gameObject.tag == "MovingPlatform")
        {
            FrictionJoint2D rb2d = collision.gameObject.GetComponent<FrictionJoint2D>();
            numberOfBounces = 1;
            rb2d.connectedBody = rb;
            collision.gameObject.GetComponent<PlatformMove>().activate = true;
            if (playHitSound)
            {
                audioS.PlayOneShot(groundSound, 1F);
                playHitSound = false;
            }
        }
        if (collision.collider.gameObject.tag == "SmallPlatform")
        {
            FrictionJoint2D rb2d = collision.gameObject.GetComponent<FrictionJoint2D>();
            numberOfBounces = 1;
            rb2d.connectedBody = rb;
            if (playHitSound)
            {
                audioS.PlayOneShot(groundSound, 1F);
                playHitSound = false;
            }
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
       
        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Platforms"))
        {
            maxSpeedAir = 14;
            maxSpeedGround = 14;        
            if (this.gameObject.activeSelf)
                this.transform.SetParent(null);


        }       
        if (collision.collider.gameObject.tag == "MovingPlatform")
        {
            FrictionJoint2D rb2d = collision.gameObject.GetComponent<FrictionJoint2D>();
            rb2d.connectedBody = null;            
        }
        if (collision.collider.gameObject.tag == "SmallPlatform")
        {
            FrictionJoint2D rb2d = collision.gameObject.GetComponent<FrictionJoint2D>();
            rb2d.connectedBody = null;
        }
        if (collision.collider.gameObject.tag == "Spring")
        {            
            maxSpeedAir = 14;
            maxSpeedGround = 14;
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Platforms") ||
            collision.collider.gameObject.layer == LayerMask.NameToLayer("FallingPlatforms"))
        {
            maxSpeedAir = 14;
            maxSpeedGround = 14;         
        }
        if (collision.collider.gameObject.tag == "FastPlatL")
        {
            maxSpeedAir = 20;
           
            Vector3 dir = Quaternion.AngleAxis(collision.transform.localEulerAngles.z, Vector3.forward) * Vector3.left;
            rb.AddForce(dir * moveSpeed * 1.1f, ForceMode2D.Force);
            numberOfBounces = 1;          
            audioS.PlayOneShot(impulseSound, 1F);            
        }
        if (collision.collider.gameObject.tag == "FastPlatR")
        {
            maxSpeedAir = 20;
            maxSpeedGround = 16;
            rb.AddForce(Vector2.right * hAxis * moveSpeed * 10f, ForceMode2D.Force);
            numberOfBounces = 1;           
            audioS.PlayOneShot(impulseSound, 1F);            
        }

    }
}





