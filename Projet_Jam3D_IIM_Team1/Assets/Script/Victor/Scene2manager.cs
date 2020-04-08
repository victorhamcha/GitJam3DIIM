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
    public Transform destination;
    public Transform poulet;
    public Transform four;
    private int vague = 0;
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
                        Instantiate(spawnable, spawners[0].position, Quaternion.identity);
                       break;
                    }
                case 2:
                    {
                        Instantiate(spawnable, spawners[1].position, Quaternion.identity);
                        Instantiate(spawnable, spawners[2].position, Quaternion.identity);
                        Instantiate(spawnable, spawners[3].position, Quaternion.identity);
                        break;
                    }
                case 3:
                    {
                        Instantiate(spawnable, spawners[4].position, Quaternion.identity);
                        Instantiate(spawnable, spawners[5].position, Quaternion.identity);
                        Instantiate(spawnable, spawners[6].position, Quaternion.identity);
                        break;
                    }
                case 4:
                    {
                        Instantiate(spawnable, spawners[7].position, Quaternion.identity);
                        Instantiate(spawnable, spawners[8].position, Quaternion.identity);
                        break;
                    }
                case 5:
                    {
                        Instantiate(spawnable, spawners[9].position, Quaternion.identity);
                        Instantiate(spawnable, spawners[10].position, Quaternion.identity);
                        vague = 0;
                        break;
                    }
            }
            vague++;
            couldown = couldownSpawn;
        }
        if (dragAndDrop.item.transform == poulet && Vector3.Distance(poulet.position, four.position) < 2)
        {
            four.gameObject.GetComponent<Renderer>().material.color = Color.green;
            if(Input.GetKeyDown(KeyCode.F))
            {
                Debug.Log("win()");
            }
        }
        else
        {
            four.gameObject.GetComponent<Renderer>().material.color = Color.white;
        }

        
    }
}
