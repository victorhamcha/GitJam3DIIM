using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDropManager : MonoBehaviour
{
    // To see if we are in it //
    public Material SelectableMaterial;
    public Material originalMaterial;
    public Material grabbedOriginalMaterial;
    private Transform _selection;
    public LayerMask dragabble;
    public float distanceTOObjects = 3.0f; 
    private bool _in = false;
    //::::::::::::::::::::::::::::::::::::::::::::// 
    //Drag&Drop//
    private bool holding;
    float ellapsedtime = 0.1f;
    public GameObject item;
    public Transform posObject;
    private ObjectsInteractions theObject;
    //lancé//
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
            if(selectionRenderer!=null)
            {

                originalMaterial = selection.gameObject.GetComponent<ObjectsInteractions>().originalMaterial;
                selectionRenderer.material = SelectableMaterial;
            }
            if(Input.GetKeyDown(KeyCode.Mouse0))
            {
                item = Grab(hit.transform.gameObject);
                
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
            item.GetComponent<Renderer>().material = SelectableMaterial;
            
            
            if(ellapsedtime>0)
            {
                ellapsedtime -= Time.deltaTime;
            }
            if (Input.GetKeyDown(KeyCode.Mouse0)&&ellapsedtime<=0)
            {

                Drop();
               
                Debug.Log("drop");
            }
            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                Throw();

                Debug.Log("shoot");
            }
        }
    }

    public GameObject Grab(GameObject grabbedObject)
    {
        holding = true;
        grabbedOriginalMaterial = grabbedObject.GetComponent<ObjectsInteractions>().originalMaterial;
        theObject = grabbedObject.GetComponent<ObjectsInteractions>();
        theObject.grabbed = true;
        theObject.cam = Camera.main.GetComponent<ThreeDPlayerLooking>();
        grabbedObject.GetComponent<Rigidbody>().isKinematic = true;
        grabbedObject.GetComponent<Collider>().isTrigger = true;
        grabbedObject.transform.SetParent(posObject);
        return grabbedObject;
    }

    private void Drop()
    {
        holding = false;
        item.GetComponent<Rigidbody>().isKinematic = false;
        item.GetComponent<Renderer>().material = grabbedOriginalMaterial;
        item.transform.SetParent(null);
        item.GetComponent<Collider>().isTrigger = false;
        theObject.cam.minRotation = 90.0f;
        theObject.grabbed = false;
        theObject = null;
        item = null;
        ellapsedtime = 0.1f;
    }
    private void Throw()
    {
        item.GetComponent<Renderer>().material = grabbedOriginalMaterial;
        item.GetComponent<Rigidbody>().isKinematic = false;
        item.GetComponent<Rigidbody>().AddForce( Camera.main.transform.forward* throwForce);
        item.transform.SetParent(null);
        holding = false;
        item.GetComponent<Collider>().isTrigger = false;
        theObject.grabbed = false;
        theObject.cam.minRotation = 90.0f;
        theObject.throns = true;
        theObject = null;
        item = null;
        ellapsedtime = 0.1f;
    }
}
