using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidBodyMouvement : MonoBehaviour
{
  
    public float normalSpeed = 12f;
    public float slideSpeed = 25;
    public float jumpHeight = 10f;

    private float speed;
    private Rigidbody _rb;
    private CapsuleCollider col;
   
    private bool slide = false;
    public bool isGrounded = true;
    public float slideTimer;
    public float slideTime=0.8f;

    public LayerMask groundMask;
    [SerializeField]
    bool mouved = false;
    private float helptime =0.1f;

    void Start()
    {
        FindObjectOfType<SoundManager>().PlaySound("Epique");
        _rb = GetComponent<Rigidbody>();
        col = GetComponent<CapsuleCollider>();
        speed = normalSpeed;
        slideTimer = slideTime;
    }

    // Update is called once per frame
    void Update()
    {

        if(Time.timeScale!=0)
        {
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            Vector3 move = (transform.right * x + transform.forward * z);

            bool inMouvement = move.x+move.z+move.y !=0 ;
            if(!inMouvement&&mouved)
            {
                helptime -= Time.deltaTime;
            }
            else
            {
                helptime = 0.1f;
            }
            if((Input.GetKeyDown(KeyCode.Z)|| Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))&&!mouved)
            {
                mouved = true;
            }
            if(!inMouvement&&mouved&&helptime<0)
            {
                FindObjectOfType<GameManager>().ReloadLevel();
            }
            
            move = Vector3.ClampMagnitude(move, 1);
            //Vector3 move = new Vector3(x, 0, z);
            //_rb.AddForce(move*speed,ForceMode.VelocityChange); //Voiture
            // _rb.velocity = move * speed;
            _rb.MovePosition(transform.position + (move * speed * Time.deltaTime));

            if (Input.GetButton("Jump") && isGrounded)
            {
                _rb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
                isGrounded = false;
                FindObjectOfType<SoundManager>().PlaySound("Saut", transform);
               
            }
            if (Input.GetKeyDown(KeyCode.LeftShift)&&!slide)
            {
                // transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y/5, transform.localScale.z);
                col.height /= 5;
                speed = slideSpeed;
                slide = true;
            }
           

            
        }
        else
        {
            mouved = false;
        }

        if(slide)
        {
           
            if(slideTimer>0)
            {
                slideTimer -= Time.deltaTime;
            }
            else
            {
                slide = false;
                slideTimer = slideTime;
                speed = normalSpeed;
                // transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y *5, transform.localScale.z);
                col.height *= 5;
            }
        }
       
            
        


    }

    private bool IsGrounded()
    {

        return Physics.CheckCapsule(col.bounds.center, new Vector3(col.bounds.center.x, col.bounds.min.y, col.bounds.center.z), col.radius * 0.9f, groundMask);
    }


    private void OnCollisionEnter(Collision collision)
    {
       if(collision.gameObject.tag=="platforme")
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "platforme")
        {
            isGrounded = false;
        }
    }
}
