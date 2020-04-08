using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public float temps;
    public GameObject menuPauseUI;

    void BackMenu()
    {
        SceneManager.LoadScene("MenueP", LoadSceneMode.Single);
    }

    void LoadCredit()
    {
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

    void Quitter()
    {
        temps -= Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("quiter");
            Application.Quit();
        }
        else if (temps <= 0)
        {
            Debug.Log("quiter2");
            Application.Quit();

        }
    }


}
