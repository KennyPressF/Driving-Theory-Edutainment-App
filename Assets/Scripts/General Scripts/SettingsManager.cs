using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SettingsManager : MonoBehaviour
{
    [Header("Music")]
    [SerializeField] Slider musicSlider;
    [SerializeField] float musicVolume;
    [SerializeField] AudioMixer musicMixer;

    [Header("SFX")]
    [SerializeField] Slider sfxSlider;
    [SerializeField] float sfxVolume;
    [SerializeField] AudioMixer sfxMixer;

    [Header("Defaults")]
    [SerializeField] Button defaultSettingsButton;
    [SerializeField] float defaultMusicVolume;
    [SerializeField] float defaultSFXVolume;

    AudioManager audioManager;

    void Awake()
    {
        audioManager = FindObjectOfType<AudioManager>();

        if (PlayerPrefs.HasKey("Music Volume")) { return; }
        else { PlayerPrefs.SetFloat("Music Volume", defaultMusicVolume); }

        if (PlayerPrefs.HasKey("SFX Volume")) { return; }
        else { PlayerPrefs.SetFloat("SFX Volume", defaultSFXVolume); }
    }

    private void Start()
    {
        musicVolume = PlayerPrefs.GetFloat("Music Volume");
        sfxVolume = PlayerPrefs.GetFloat("SFX Volume");

        musicSlider.value = musicVolume;
        sfxSlider.value = sfxVolume;
    }

    public void SetMusicVolume(float musicVolume)
    {
        musicMixer.SetFloat("musicMixerVolume", musicVolume);
        if (musicVolume <= -30f) { musicMixer.SetFloat("musicMixerVolume", -80f); }
        PlayerPrefs.SetFloat("Music Volume", musicVolume);
    }

    public void SetSFXVolume(float sfxVolume)
    {
        sfxMixer.SetFloat("sfxMixerVolume", sfxVolume);
        if (sfxVolume <= -30f) { sfxMixer.SetFloat("sfxMixerVolume", -80f); }
        PlayerPrefs.SetFloat("SFX Volume", sfxVolume);
    }

    public void ResetDefaultSettings()
    {
        audioManager.PlayAudio("Button Press");

        musicSlider.value = defaultMusicVolume;
        PlayerPrefs.SetFloat("Music Volume", defaultMusicVolume);

        sfxSlider.value = defaultSFXVolume;
        PlayerPrefs.SetFloat("SFX Volume", defaultSFXVolume);
    }
}
