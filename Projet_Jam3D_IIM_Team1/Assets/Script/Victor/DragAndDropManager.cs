﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDropManager : MonoBehaviour
{
    // To see if we are in it //
    public Material SelectableMaterial;
    public Material originalMaterial;
    private Transform _selection;
    private Renderer _selRenderer;
    public LayerMask dragabble;
    public float distanceTOObjects = 3.0f; 
    private bool _in = false;
    //::::::::::::::::::::::::::::::::::::::::::::// 
    //Drag&Drop//
    private bool holding;
    float ellapsedtime = 0.1f;
    public GameObject item;
    
    private  float grabbedObjectSize;
    public float throwForce;
    public Vector3 dragOffSet;
    public Transform posObject;
    private ObjectsInteractions theObject;
   
    void Update()
    {


        if(_selection!=null&&!_in)
        {
            Renderer selectionRenderer = _selection.GetComponent<Renderer>();
            selectionRenderer.material = originalMaterial;
            _selection = null;

    
          

        }
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, distanceTOObjects,dragabble))
        {
            Transform selection = hit.transform;
            Renderer selectionRenderer = selection.GetComponent<Renderer>();
            if(selectionRenderer!=null&&selectionRenderer.material.color!=SelectableMaterial.color)
            {

                originalMaterial = selectionRenderer.material;
                selectionRenderer.material = SelectableMaterial;
            }
            if(Input.GetKeyDown(KeyCode.Mouse0))
            {
                holding = true;
                item = hit.transform.gameObject;
                grabbedObjectSize=item.GetComponent<Renderer>().bounds.size.magnitude;
                theObject = item.GetComponent<ObjectsInteractions>();
                theObject.grabbed = true;
                theObject.cam = Camera.main.GetComponent<ThreeDPlayerLooking>();
                //item.GetComponent<Rigidbody>().velocity = Vector3.zero;
                //item.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
                item.GetComponent<Rigidbody>().isKinematic = true;
                item.GetComponent<Collider>().isTrigger = true;
                item.transform.SetParent(posObject);
               
                
               // item.GetComponent<Rigidbody>().useGravity = false;
                
            }
            _selection = selection;
            _in = true;
           
        }
        else
        {
            _in = false;
        }

        if(holding)
        {
          

            //Vector3 newPos = _player.position + dragOffSet + Camera.main.ScreenToWorldPoint(Input.mousePosition) * grabbedObjectSize;
            item.transform.position = posObject.position;
            //Ray objRay = new Ray(newPos, Vector3.left);
            //Debug.DrawRay(objRay.origin, objRay.direction, Color.green);

            item.GetComponent<Renderer>().material = SelectableMaterial;
            
            
            if(ellapsedtime>0)
            {
                ellapsedtime -= Time.deltaTime;
            }
            if (Input.GetKeyDown(KeyCode.Mouse0)&&ellapsedtime<=0)
            {
                holding = false;
                item.GetComponent<Rigidbody>().isKinematic = false;
                item.GetComponent<Renderer>().material = originalMaterial;
                item.transform.SetParent(null);
                item.GetComponent<Collider>().isTrigger = false;
                theObject.grabbed = false;
                theObject = null;
                item = null;
                ellapsedtime = 0.1f;
                
               
                Debug.Log("drop");
            }
            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                item.GetComponent<Renderer>().material = originalMaterial;
                item.GetComponent<Rigidbody>().isKinematic = false;
                item.GetComponent<Rigidbody>().AddForce(posObject.forward * throwForce);
                item.transform.SetParent(null);
                holding = false;
                item.GetComponent<Collider>().isTrigger = false;
                theObject.grabbed = false; 
                theObject.throns = true;
                theObject = null;
                item = null;
                ellapsedtime = 0.1f;
                


                Debug.Log("shoot");
            }
        }
    }
}
