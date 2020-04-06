using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidBodyMouvement : MonoBehaviour
{
  
    public float speed = 12f;
    public float jumpHeight = 10f;

    private Rigidbody _rb;
    private CapsuleCollider col;

    bool isGrounded = true;

    public LayerMask groundMask;

   

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        col = GetComponent<CapsuleCollider>();
    }

    // Update is called once per frame
    void Update()
    {

        if(Time.timeScale!=0)
        {
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            Vector3 move = (transform.right * x + transform.forward * z);
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
                col.height /= 2;
            }
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                col.height *= 2;
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
