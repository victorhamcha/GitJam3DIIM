using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackMenu : MonoBehaviour
{
    void Debut()
    {
        SceneManager.LoadScene("MenueP", LoadSceneMode.Single);
    }
}
