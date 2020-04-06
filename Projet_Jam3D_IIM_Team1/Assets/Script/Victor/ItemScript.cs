using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScript : MonoBehaviour
{
    public bool holding;
    public GameObject itemParent;
    public Rigidbody _rigidbody;

    private Vector3 ObjPosition;



  
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(holding)
        {
            _rigidbody.velocity=Vector3.zero;
            _rigidbody.angularVelocity = Vector3.zero;
            transform.SetParent(itemParent.transform);
            
        }
        else
        {
            ObjPosition = transform.position;
            transform.SetParent(null);
            _rigidbody.useGravity = true;
            transform.position = ObjPosition;
        }
    }
}
