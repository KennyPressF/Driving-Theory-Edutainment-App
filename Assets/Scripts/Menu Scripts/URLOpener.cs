using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class URLOpener : MonoBehaviour
{
    [SerializeField] string highwayCodeURL;
    [SerializeField] string roadSignsURL;

    AudioManager audioManager;

    private void Awake()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }

    public void OpenHighwayCodeURL()
    {
        audioManager.PlayAudio("Button Press");
        Application.OpenURL(highwayCodeURL);
    }

    public void OpenRoadSignsURL()
    {
        audioManager.PlayAudio("Button Press");
        Application.OpenURL(roadSignsURL);
    }
}
