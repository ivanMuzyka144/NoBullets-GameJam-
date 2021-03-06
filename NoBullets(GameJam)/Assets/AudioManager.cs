﻿using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
	public Sound[] sounds;

	void Awake()
    {
        
		foreach(Sound s in sounds)
		{
			s.source = gameObject.AddComponent<AudioSource>();
			s.source.clip = s.clip; 
		}

	}

    // Update is called once per frame
    public void Play(string name)
    {
		Sound s = Array.Find(sounds, sounds => sounds.name == name);
		s.source.Play();
    }
}
