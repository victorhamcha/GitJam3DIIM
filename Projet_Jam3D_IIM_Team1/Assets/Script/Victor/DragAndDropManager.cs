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
    private GameObject item;
    public Transform _player;
    private  float grabbedObjectSize;
    public float throwForce;
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

                item.GetComponent<Rigidbody>().velocity = Vector3.zero;
                item.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
                
               
                
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

            Vector3 newPos = _player.position + Camera.main.transform.forward * grabbedObjectSize;
            item.transform.position = newPos;
            item.GetComponent<Renderer>().material = SelectableMaterial;
            
            
            if(ellapsedtime>0)
            {
                ellapsedtime -= Time.deltaTime;
            }
            if (Input.GetKeyDown(KeyCode.Mouse0)&&ellapsedtime<=0)
            {
                holding = false;
                item.GetComponent<Renderer>().material = originalMaterial;
                //item = null;
                ellapsedtime = 0.1f;
                
                //item.GetComponent<Rigidbody>().velocity = savedVel;
                //item.GetComponent<Rigidbody>().angularVelocity = savedAngularVel;              

                Debug.Log("drop");
            }
            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                item.GetComponent<Renderer>().material = originalMaterial;
                item.GetComponent<Rigidbody>().AddForce(_player.forward * throwForce);
                holding = false;
                //item = null;
                ellapsedtime = 0.1f;

                //item.GetComponent<Rigidbody>().velocity = savedVel;
                //item.GetComponent<Rigidbody>().angularVelocity = savedAngularVel;              

                Debug.Log("shoot");
            }
        }
    }
}
