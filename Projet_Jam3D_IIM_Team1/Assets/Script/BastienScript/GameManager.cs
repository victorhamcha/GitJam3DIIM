using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum GameState { MAIN_MENU, IN_GAME }
public class GameManager : MonoBehaviour
{
    private static GameManager instance = null;

    //define a list
    public static List<GameObject> myListObjects = new List<GameObject>();
    //Number of objects spawned
    public static int numSpawned = 0;
    [SerializeField] private int numToSpawn = 5;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        //Important note: place your prefabs folder(or levels or whatever) 
        //in a folder called "Resources" like this "Assets/Resources/Prefabs"
        Object[] subListObjects = Resources.LoadAll("Prefabs", typeof(GameObject));
        //This may be sloppy
        foreach (GameObject subListObject in subListObjects)
        {
            GameObject lo = (GameObject)subListObject;

            myListObjects.Add(lo);
        }
        Vector3 startPosition = transform.position;
    }

    void SpawnRandomObject()
    {
        //spawns item in array position between 0 and 100
        //int whichItem = Random.Range(0, 100);

        GameObject myObj = Instantiate(myListObjects[0]) as GameObject;
        //myObj.GetComponent<Rigidbody>().isKinematic = true;

        numSpawned++;

        myObj.transform.position = transform.position;
    }

    void Update()
    {
        if (numToSpawn > numSpawned)
        {
            //where your instantiated object spawns from
            transform.position = new Vector3(0, 10, 0);
            SpawnRandomObject();
        }
    }
}
