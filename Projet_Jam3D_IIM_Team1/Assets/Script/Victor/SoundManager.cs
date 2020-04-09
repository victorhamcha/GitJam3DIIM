using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SoundManager : MonoBehaviour
{
    public static SoundManager instance = null;
    //public List<AudioClip> sons = new List<AudioClip>();
    public Dictionary<string, AudioClip> soundGenerator = new Dictionary<string, AudioClip>();
    
    public GameObject sound;
    
    
    [System.Serializable]
    public class DicoClip
    {
        public string soundName;
        public AudioClip clip;
    }

    public DicoClip[] clips;

    private void Awake()
    {
        for (int i=0; i<clips.Length;i++)
        {
            soundGenerator[clips[i].soundName] = clips[i].clip;
        }
        
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

    public void PlaySound(string soundName,Transform position)
    {
       
       GameObject lesond= Instantiate(sound,position.position,position.rotation,position);
       lesond.GetComponent<TheSound>().soundName = soundName;
    }


    
   
   
}
