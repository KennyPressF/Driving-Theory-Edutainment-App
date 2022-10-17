using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    [SerializeField] Sound[] soundArray;

    private void Awake()
    {
        SetUpAudioManagerSingleton();

        foreach (Sound sound in soundArray)
        {
            sound.audioSource = gameObject.AddComponent<AudioSource>();
            sound.audioSource.clip = sound.audioClip;
            sound.audioClipLength = sound.audioSource.clip.length;

            sound.audioSource.volume = sound.volume;
            sound.audioSource.pitch = sound.pitch;
            sound.audioSource.outputAudioMixerGroup = sound.mixerGroup;
            sound.audioSource.loop = sound.loop;
        }
    }

    private void SetUpAudioManagerSingleton()
    {
        int numberOfAudioManagers = FindObjectsOfType<AudioManager>().Length;

        if (numberOfAudioManagers > 1) { Destroy(gameObject); }
        else { DontDestroyOnLoad(gameObject); return; }
    }

    public void PlayAudio(string soundName)
    {
        Sound s = Array.Find(soundArray, s => s.name == soundName);
        s.audioSource.Play();
    }

    public void StopAudio(string soundName)
    {
        Sound s = Array.Find(soundArray, s => s.name == soundName);
        s.audioSource.Stop();
    }

    public float GetWaitTime(string soundName)
    {
        Sound s = Array.Find(soundArray, s => s.name == soundName);
        float audioLength = s.audioClipLength;
        return audioLength;
    }
}
