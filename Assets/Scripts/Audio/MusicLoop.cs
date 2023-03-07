using System.Collections;
using System.Collections.Generic;

//Script
using UnityEngine;

public class MusicLoop : MonoBehaviour
{
    public AudioSource musicSource;
    public AudioClip musicStart;

    // Start is called before the first frame update
    void Start()
    {
        if(musicSource != null && musicStart != null){
            musicSource.PlayOneShot(musicStart);
            musicSource.PlayScheduled(AudioSettings.dspTime + musicStart.length);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}