using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//public enum GameState { MAIN_MENU, IN_GAME }
public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    private Scene1 scene1;
    private Scene2manager scene2Manager;
    private Scene3Manager scene3Manager;
    private Recipe recipe;

    private bool once = false;
    private bool levelCompleted = false;

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

    void Update()
    {
        switch (getLevelNum())
        {
            case 1:
                if(scene1 == null)
                {
                    scene1 = (Scene1)GameObject.FindObjectOfType(typeof(Scene1));
                }
                if(scene1.verifQUilles())
                {
                    if (!once)
                    {
                        levelCompleted = true;
                        StartCoroutine("PlayNextLevelSound");
                        once = true;
                    }
                }
                break;
            case 2:
                if (scene2Manager == null)
                {
                    scene2Manager = (Scene2manager)GameObject.FindObjectOfType(typeof(Scene2manager));
                }
                if (scene2Manager.win)
                {
                    if (!once)
                    {
                        StartCoroutine("PlayNextLevelSound");
                        once = true;
                    }
                }
                break;
            case 3:
                if (scene3Manager == null)
                {
                    scene3Manager = (Scene3Manager)GameObject.FindObjectOfType(typeof(Scene3Manager));
                }
                if (scene3Manager.win)
                {
                    if (!once)
                    {
                        StartCoroutine("PlayNextLevelSound");
                        once = true;
                    }
                }
                break;
            case 4:
                if (recipe == null)
                {
                    recipe = (Recipe)GameObject.FindObjectOfType(typeof(Recipe));
                }
                if (recipe.IsTheRecipeGood())
                {
                    NextLevel();
                }
                break;
            default:
                break;
        }
        //if current scene is number 1 => Scene1 ? yes => next scene (scene manager) : no then continue
        //if current scene is number 2 => Scene2Manager ? yes => next scene (scene manager) : no then continue
        //if current scene is number 3 => Scene3Manager ? yes => next scene (scene manager) : no then continue
        //if current scene is number 4 => IsTheRecipeGood ? yes => next scene (scene manager) : no then continue
    }

    void BackMenu()
    {
        SceneManager.LoadScene("MenueP", LoadSceneMode.Single);
    }

    void LoadCredit()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Credit", LoadSceneMode.Single);
    }

    public void NextLevel()
    {
        if (SceneManager.sceneCountInBuildSettings != SceneManager.GetActiveScene().buildIndex)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1, LoadSceneMode.Single);
            //if (SceneManager.GetActiveScene().buildIndex != 0)
            //    menuPauseUI.SetActive(false);
            Time.timeScale = 1;
        }
        else
        {
            Debug.Log("You've reach the last level");
            LoadCredit();
        }
    }

    public void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
        Time.timeScale = 1;
    }

    public int getLevelNum()
    {
        return (SceneManager.GetActiveScene().buildIndex);
    }

    private IEnumerator PlayNextLevelSound()
    {
        Time.timeScale = 0f;
        SoundManager.instance.PlaySound("Scene" + (SceneManager.GetActiveScene().buildIndex + 1), this.transform);
        yield return new WaitForSecondsRealtime(SoundManager.instance.SoundWithHisTime("Scene" + (SceneManager.GetActiveScene().buildIndex + 1)) + 0.5f);
        NextLevel();
        once = false;
    }

    public bool IsLevelComplete()
    {
        return levelCompleted;
    }
}
