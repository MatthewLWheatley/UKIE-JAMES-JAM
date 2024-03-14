using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.Audio;
using UnityEngine;
using Unity.VisualScripting;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    public Sound[] music;
    public static AudioManager instance;
    public AudioDistortionFilter distortionFilter;
    public float distortion;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
        foreach(Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }

        foreach (Sound s in music)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }

        distortionFilter = gameObject.AddComponent<AudioDistortionFilter>();
        distortionFilter.distortionLevel = distortion;
    }

   public void PlaySFX (string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if(s == null)
        {
            Debug.LogWarning("sound: " + name + " not found");
            return;
        }
        s.source.Play();
    }

    public void PlayMusic(string name)
    {
        Sound s = Array.Find(music, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("sound: " + name + " not found");
            return;
        }
        s.source.Play();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            PlaySFX("click1");
        }

        if (Input.GetMouseButtonUp(0))
        {
            PlaySFX("click2");
        }
    }
}
