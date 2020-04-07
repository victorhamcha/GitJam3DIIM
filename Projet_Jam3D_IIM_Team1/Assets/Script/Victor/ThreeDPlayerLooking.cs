
//// temple Run //
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class ThreeDPlayerLooking : MonoBehaviour
//{
//    // Start is called before the first frame update
//    public float mouseSnesy = 0.100f;
//    public Transform playerBody;
//    private float xRotation = 0f;
//    bool rotateR = false;
//    bool CanRotate;
//    Vector3 changeAngle;
//    float turnAngle;
//    public bool canRotate = false;
//    void Start()
//    {
//        Cursor.lockState = CursorLockMode.Locked;
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        //float mouseX = Input.GetAxis("Mouse X")*mouseSnesy;
//        //float mouseX = Input.GetAxis("Mouse X") * mouseSnesy;
//        float mouseY = Input.GetAxis("Mouse Y") * mouseSnesy;

//        xRotation -= mouseY;
//        // xRotation = Mathf.Clamp(xRotation, -90f,90f);

//        //transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
//        if (!rotateR)
//        {
//            if(Input.GetKeyDown(KeyCode.RightArrow))
//            {
//                turnAngle = 90f;
//                rotateR = true;
//                changeAngle = playerBody.transform.eulerAngles;
//            }
//            else if(Input.GetKeyDown(KeyCode.LeftArrow))
//            {
//                turnAngle = -90f;
//                rotateR = true;
//                changeAngle = playerBody.transform.eulerAngles;
//            }


//        }
//        if (rotateR)
//        {
//            Vector3 to = new Vector3(0, changeAngle.y+90, 0);
//            Vector3 too = new Vector3(0, changeAngle.y-90, 0);
//            if (Vector3.Distance(transform.eulerAngles, too) > 0.01f)
//            {
//                playerBody.transform.eulerAngles += new Vector3(0, -1, 0);
//                //playerBody.transform.eulerAngles += -Vector3.Lerp(transform.rotation.eulerAngles, to, Time.deltaTime*mouseSnesy);
//            }
//            else
//            {
//                playerBody.transform.eulerAngles = to;
//                rotateR = false;
//                Debug.Log("mlkj");
//            }

//        }
//    }
//}

//NORMAL//
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThreeDPlayerLooking : MonoBehaviour
{
    // Start is called before the first frame update
    public float mouseSnesy = 100f;
    public Transform playerBody;
    private float xRotation = 0f;
    public float maxRotation;
    public float minRotation;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
     
        if (Time.timeScale != 0.0f)
        {
            float mouseX = Input.GetAxis("Mouse X") * mouseSnesy;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSnesy;

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, maxRotation, minRotation);

            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            playerBody.Rotate(Vector3.up * mouseX);
        }
       
    }
}

