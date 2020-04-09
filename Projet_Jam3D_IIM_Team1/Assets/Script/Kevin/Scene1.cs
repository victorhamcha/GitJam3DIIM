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
    private bool aToucherQuille = false; // on regarde si la pastèque a toucher la Quilles ou pas

    private void Start() // ici on recup la position initial des Quilles au lancement du jeu
    {
        initialRotations = new float[Quilles.Length];
        for (int i = 0; i < Quilles.Length; i++ )
        {
            initialRotations[i] = Quilles[i].transform.eulerAngles.x; // on recup le X

        }
    }

    void Update()
    {
        if(aToucherQuille) // si on a toucher la Quilles
        {
            temps -= Time.deltaTime; // déclance un timeur
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

    public bool verifQUilles()
    {
        for(int i = 0; i < Quilles.Length; i++)     // on va verifier la rotation de chaque Quille
        {
            float rotationActuelle = Quilles[i].transform.eulerAngles.x;       // on stocke la rotation actuelle 
            float rotationInitial = initialRotations[i];                       // on stocke la rotation initial
            float diffRotation = rotationActuelle - rotationInitial;            // on calcul la différence entre les 2 
            if(Mathf.Abs(diffRotation) < angleCoucher && !aToucherQuille) // valeur absolue => on regarde si la rotation est inférieur a l'angle voulue
            {
                return false; // on retourne false si toute les Quilles ne sont pas tomber
            }
        }

        return true; // retourne true si toute les Quille sont coucher
        
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("biere"))
        {
            Debug.Log("toucher");   //=> collision entre la pasteque et la Quille
            aToucherQuille = true; 


        }
       
    }



}
