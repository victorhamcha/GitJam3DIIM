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
    bool slide = false;
    public bool isGrounded = true;
    public float slideTimer;
    public float slideTime=0.8f;

    public LayerMask groundMask;

   

    void Start()
    {
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
            move = Vector3.ClampMagnitude(move, 1);
            //Vector3 move = new Vector3(x, 0, z);
            //_rb.AddForce(move*speed,ForceMode.VelocityChange); //Voiture
            // _rb.velocity = move * speed;
            _rb.MovePosition(transform.position + (move * speed * Time.deltaTime));

            if (Input.GetButton("Jump") && isGrounded)
            {
                _rb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
                isGrounded = false;
            }
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y/5, transform.localScale.z);
                speed = slideSpeed;
                slide = true;
            }
            if (Input.GetKeyUp(KeyCode.LeftShift)&&slide)
            {
               
               
            }
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
                transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y *5, transform.localScale.z);

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
