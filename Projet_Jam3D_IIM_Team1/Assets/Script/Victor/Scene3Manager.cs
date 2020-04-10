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
    private GameObject bombe;
    public GameObject _player;
    private DragAndDropManager drag;
    private bool grabbed;
    public Transform sol;
    public float SoundTime;

    public bool win;


    [SerializeField]
    private float AngleChicken;


    

    void Start()
    {
        timer = timerValue;
        direction = Random.Range(-2, 2);
        trajectoire = AngleChicken* direction;
        drag = FindObjectOfType<DragAndDropManager>();
        SoundTime= FindObjectOfType<SoundManager>().SoundWithHisTime("Scene3");
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
          
            bombe= Instantiate(poulet, four.position, Quaternion.identity);
            bombe.GetComponent<Rigidbody>().AddForce(new Vector3( 100 * throwPower, 110* throwPower, trajectoire),ForceMode.Force);
            
           
        }

        if(bombe!=null&&!grabbed)
        {
            float distance = Vector3.Distance(bombe.transform.position, _player.transform.position);
           
            if(distance<=2f)
            {
                drag.item = drag.Grab(bombe);
                win = true;
                grabbed = true;
            }
         
        }
    }
}
