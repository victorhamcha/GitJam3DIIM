using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camion : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Perdu");
        }
    }
}
