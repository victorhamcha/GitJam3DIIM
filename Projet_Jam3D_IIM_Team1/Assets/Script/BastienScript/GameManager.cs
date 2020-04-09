using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//public enum GameState { MAIN_MENU, IN_GAME }
public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    void Update()
    {
        //if current scene is number 1 => Scene1 ? yes => next scene (scene manager) => no then continue
        //if current scene is number 2 => Scene2Manager ? yes => next scene (scene manager) => no then continue
        //if current scene is number 3 => Scene3Manager ? yes => next scene (scene manager) => no then continue
        //if current scene is number 4 => IsTheRecipeGood ? yes => next scene (scene manager) => no then continue
    }
}
