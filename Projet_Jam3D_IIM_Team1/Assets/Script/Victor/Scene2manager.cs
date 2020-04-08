using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene2manager : MonoBehaviour
{
    public List<Transform> spawners = new List<Transform>();
    public GameObject spawnable;
    public DragAndDropManager dragAndDrop;
    public float couldownSpawn;
    private float couldown;
   // public Transform destination;
    public Transform poulet;
    public Transform four;
    private int vague = 0;
    private List<GameObject> objectSpawned=new List<GameObject>();
    void Start()
    {
        couldown = couldownSpawn;
    }

    // Update is called once per frame
    void Update()
    {
        if(couldown>0)
        {
            couldown -= Time.deltaTime;
        }
        else
        {
            switch(vague)
            {
                case 0:
                    {
                        break;
                    } 
                case 1:
                    {
                       GameObject spawned= Instantiate(spawnable, spawners[0].position, Quaternion.Euler(0,-90,-90));
                        objectSpawned.Add(spawned);

                       break;
                    }
                case 2:
                    {
                        GameObject spawned=Instantiate(spawnable, spawners[1].position, Quaternion.Euler(0, -90, -90));
                        GameObject spawned1=Instantiate(spawnable, spawners[2].position, Quaternion.Euler(0, -90, -90));
                        GameObject spawned2 =Instantiate(spawnable, spawners[3].position, Quaternion.Euler(0, -90, -90));
                        objectSpawned.Add(spawned);
                        objectSpawned.Add(spawned1);
                        objectSpawned.Add(spawned2);

                        break;
                    }
                case 3:
                    {
                        GameObject spawned= Instantiate(spawnable, spawners[4].position, Quaternion.Euler(0, -90, -90));
                        GameObject spawned1= Instantiate(spawnable, spawners[5].position, Quaternion.Euler(0, -90, -90));
                        GameObject spawned2= Instantiate(spawnable, spawners[6].position, Quaternion.Euler(0, -90, -90));
                        objectSpawned.Add(spawned);
                        objectSpawned.Add(spawned1);
                        objectSpawned.Add(spawned2);
                        break;
                    }
                case 4:
                    {

                        GameObject spawned=Instantiate(spawnable, spawners[7].position, Quaternion.Euler(0, -90, -90));
                        GameObject spawned1=Instantiate(spawnable, spawners[8].position, Quaternion.Euler(0, -90, -90));
                        objectSpawned.Add(spawned);
                        objectSpawned.Add(spawned1);
                  
                        break;
                    }
                case 5:
                    {
                        GameObject spawned=Instantiate(spawnable, spawners[9].position, Quaternion.Euler(0, -90, -90));
                        GameObject spawned1= Instantiate(spawnable, spawners[10].position, Quaternion.Euler(0, -90, -90));
                        objectSpawned.Add(spawned);
                        objectSpawned.Add(spawned1);
                        vague = 0;
                        break;
                    }
            }
            vague++;
            couldown = couldownSpawn;
        }


        for(int i=0; i<objectSpawned.Count;i++)
        {
            if(objectSpawned[i].transform.position.y<-20)
            {
                Destroy(objectSpawned[i]);
                
                objectSpawned.RemoveAt(i);
            }
        }

        if(dragAndDrop.item!=null)
        {
            if (dragAndDrop.item.transform == poulet && Vector3.Distance(poulet.position, four.position) < 2)
            {
                four.gameObject.GetComponent<Renderer>().material.color = Color.green;
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    Debug.Log("win()");
                    Destroy(poulet.gameObject);
                }
            }
            else
            {
                four.gameObject.GetComponent<Renderer>().material.color = Color.white;
            }
        }
        else
        {
            four.gameObject.GetComponent<Renderer>().material.color = Color.white;
        }


    }
}
