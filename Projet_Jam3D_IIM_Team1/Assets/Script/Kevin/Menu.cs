using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject menuPauseUI;

    void BackMenu()
    {
        SceneManager.LoadScene("MenueP", LoadSceneMode.Single);
    }

    void LoadCredit()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Credit", LoadSceneMode.Single);
    }

    void Debut()
    {
        SceneManager.LoadScene("SceneGeneral", LoadSceneMode.Single);
    }

    void Reprendre()
    {
        menuPauseUI.SetActive(false);
        Time.timeScale = 1;
    }


}
