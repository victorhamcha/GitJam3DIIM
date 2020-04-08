using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SoundManager : MonoBehaviour
{
    public List<AudioSource> sons = new List<AudioSource>();
    public static List<AudioSource> son = new List<AudioSource>();
    
    
    void Start()
    {
        son = sons;
    }

    // Update is called once per frame
    void Update()
    {
      
        
    }

    public void PlaySound(int i)
    {
        if(!son[i].isPlaying)
        {
            son[i].Play();
        }
      
        
    }
    public void StopSound(int i)
    {
        son[i].Stop();
    }
   

}
