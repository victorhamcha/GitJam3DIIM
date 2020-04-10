using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoMoveTruck : MonoBehaviour
{
    [SerializeField] private float speed = 5;
    [SerializeField] private GameObject[] toSpawn;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(speed, 0, 0) * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Hi");
        if(other.gameObject.tag == "Player")
        {
            Debug.Log("You died");
            GameManager.instance.ReloadLevel();
        }
        if(other.gameObject.tag == "Start")
        {
            for (int i = 0; i < toSpawn.Length; i++)
            {
                toSpawn[i].SetActive(true);
            }
        }
        if(other.gameObject.tag == "End")
        {
            Debug.Log("END");
            GameManager.instance.ReloadLevel();
        }
        if (other.gameObject.CompareTag("WallParticles"))
        {
            Debug.Log("Oui");
            GameObject WallP = other.gameObject;
            ParticleSystem Psystem = WallP.GetComponent<ParticleSystem>();
            Psystem.Play();
        }
    }
}
