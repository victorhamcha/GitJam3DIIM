﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsInteractions : MonoBehaviour
{
    public bool throns=false;
    public GameObject throwned;
    public ThreeDPlayerLooking cam;
    public bool grabbed=false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if (throns)
        {
            Destroy(gameObject);
            throns = false;
            Instantiate(throwned, gameObject.transform.position, Quaternion.identity);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
       
    }
    private void OnTriggerEnter(Collider other)
    {
        if (grabbed)
        {
            cam.minRotation = cam.transform.rotation.eulerAngles.x;
            //Debug.Log(Camera.main.transform.rotation.x*180/Mathf.PI);
        }


    }
    private void OnTriggerExit(Collider other)
    {
        if (grabbed)
        {
            cam.minRotation = 90.0f;
            
        }
    }
}
