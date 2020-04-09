using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheSound : MonoBehaviour
{
    public SoundManager soundManager;
    public AudioSource audioSource;
    public string soundName;
    void Start()
    {
       
        soundManager = FindObjectOfType<SoundManager>();
        
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = soundManager.soundGenerator[soundName];
        audioSource.Play();
        Destroy(gameObject, audioSource.clip.length);
    }
    private void Awake()
    {
 
       
    }


    void Update()
    {
        
    }
}
