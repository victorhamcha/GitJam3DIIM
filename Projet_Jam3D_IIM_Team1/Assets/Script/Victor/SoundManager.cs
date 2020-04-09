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

    public static void PlaySound(AudioSource audio)
    {
       
           audio.Play();
        
      
        
    }
    public static void StopSound(AudioSource audio)
    {
        audio.Stop();
    }
   

}
