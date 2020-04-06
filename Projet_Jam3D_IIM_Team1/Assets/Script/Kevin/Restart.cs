using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Restart : MonoBehaviour
{
   
    void Debut()
    {
        Debug.Log("machin");
        SceneManager.LoadScene("SceneGeneral", LoadSceneMode.Single);
    }
}
