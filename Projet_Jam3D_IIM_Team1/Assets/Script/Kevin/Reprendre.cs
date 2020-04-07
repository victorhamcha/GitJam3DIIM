using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Reprendre : MonoBehaviour
{

    public GameObject menuPauseUI;

    void reprendre()
    {
        menuPauseUI.SetActive(false);
        Time.timeScale = 1;
    }

}
