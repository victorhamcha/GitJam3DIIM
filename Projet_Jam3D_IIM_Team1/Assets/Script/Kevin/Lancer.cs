using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lancer : MonoBehaviour
{
    void Debut()
    {
        SceneManager.LoadScene("SceneGeneral", LoadSceneMode.Single);
    }
}
