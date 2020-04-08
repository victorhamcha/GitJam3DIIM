using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene1 : MonoBehaviour
{

    public int compt = 0;
    public float temps = 1f;
    public GameObject[] Quilles;
    private float[] initialRotations;
    public float angleCoucher = 70f;
    private bool aToucherQuille = false;

    private void Start() // pos ini rotation
    {
        initialRotations = new float[Quilles.Length];
        for (int i = 0; i < Quilles.Length; i++ )
        {
            initialRotations[i] = Quilles[i].transform.eulerAngles.x;

        }
    }

    void Update()
    {
        if(aToucherQuille)
        {
            temps -= Time.deltaTime;
            if(temps <= 0)
            {
                if (verifQUilles())
                {
                    Debug.Log("gagner");
                }
                else
                {
                    Debug.Log("Perdu");
                }
                aToucherQuille = false;

            }
               
        }
        

    }

    bool verifQUilles()
    {
        for(int i = 0; i < Quilles.Length; i++)
        {
            float rotationActuelle = Quilles[i].transform.eulerAngles.x;
            float rotationInitial = initialRotations[i];
            float diffRotation = rotationActuelle - rotationInitial;
            if(Mathf.Abs(diffRotation) < angleCoucher) // valeur absolue
            {
                return false;
            }
        }

        return true;
        
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("biere"))
        {
            Debug.Log("toucher");
            aToucherQuille = true;


        }
       
    }



}
