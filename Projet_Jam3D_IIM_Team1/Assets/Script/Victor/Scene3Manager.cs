using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene3Manager : MonoBehaviour
{
    public GameObject poulet;
    private int direction;
    public float timerValue;
    private float timer;
    public Transform four;
    private bool go=false;
    public float throwPower;
    private float trajectoire=0;
    void Start()
    {
        timer = timerValue;
        direction = Random.Range(-2, 2);
        trajectoire = 50 * direction;
    }

    // Update is called once per frame
    void Update()

    {
        if(timer>0)
        {
            timer -= Time.deltaTime;
        }
        else if(!go)
        {
            go = true;
          
            GameObject bombe= Instantiate(poulet, four.position, Quaternion.identity);
            bombe.GetComponent<Rigidbody>().AddForce(new Vector3(-120*throwPower, 110*throwPower, trajectoire));
           
           
        }
    }
}
