using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LoadCredit : MonoBehaviour
{
    void Debut()
    {
        SceneManager.LoadScene("Credit", LoadSceneMode.Single);
    }
}
