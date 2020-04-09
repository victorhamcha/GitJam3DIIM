using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoMoveTruck : MonoBehaviour
{
    [SerializeField] private float speed = 5;
    [SerializeField] private GameObject[] ToSpawn;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(speed, 0, 0) * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Hi");
        if(other.gameObject.tag == "Start")
        {
            for (int i = 0; i < length; i++)
            {

            }
        }
    }
}
