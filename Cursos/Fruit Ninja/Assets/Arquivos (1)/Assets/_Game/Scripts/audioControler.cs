using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioControler : MonoBehaviour
{
    public AudioSource music, blade;
    public AudioClip[] bladeAudio, fruitSplashAudio;
    public AudioClip bombExplodeAudio;
    [SerializeField] private AudioSource[] audioSources;
    private GameControler gameControler;
    void Start()
    {
        gameControler = FindAnyObjectByType<GameControler>();
        EnableAndDisableAudio();
    }

  
    void Update()
    {
        
    }

    public void EnableAndDisableAudio()
    {
        if (gameControler.soundOnOff)
        {
            for (int i = 0; i<audioSources.Length; i++)
            {
                audioSources[i].mute = false;
            }
        }
        else
        {

            for (int i = 0; i < audioSources.Length; i++)
            {
                audioSources[i].mute = true;
            }
        }
    }
}
