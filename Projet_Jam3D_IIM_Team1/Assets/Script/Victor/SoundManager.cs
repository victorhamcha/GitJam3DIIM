using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SoundManager : MonoBehaviour
{
    public List<AudioClip> sons = new List<AudioClip>();
    public GameObject sound;
    public int i;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      
        
    }

    public void PlaySound(int j,Transform position)
    {
       
       GameObject lesond= Instantiate(sound,position.position,position.rotation,position);
       lesond.GetComponent<TheSound>().i = j;
    }


    public void StopSound(GameObject sound)
    {
        Destroy(sound);
    }
   
   
}
