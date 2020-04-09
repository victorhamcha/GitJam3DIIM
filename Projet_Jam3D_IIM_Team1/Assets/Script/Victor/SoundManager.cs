using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SoundManager : MonoBehaviour
{
    public static SoundManager instance = null;
    public List<AudioClip> sons = new List<AudioClip>();
    public GameObject sound;
    public int i;

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
