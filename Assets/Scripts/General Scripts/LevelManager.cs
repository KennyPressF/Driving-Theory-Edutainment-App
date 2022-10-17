using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    AudioManager audioManager;

    private void Awake()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }

    public void LoadMainMenu()
    {
        audioManager.PlayAudio("Button Press");
        SceneManager.LoadScene("Main Menu");
    }

    public void LoadTextQuiz()
    {
        audioManager.StopAudio("Main Theme");
        audioManager.PlayAudio("Button Press");
        SceneManager.LoadScene("Text Quiz");
    }

    public void LoadImageQuiz()
    {
        audioManager.StopAudio("Main Theme");
        audioManager.PlayAudio("Button Press");
        SceneManager.LoadScene("Image Quiz");
    }

    public void ReloadScene()
    {
        audioManager.PlayAudio("Button Press");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame()
    {
        audioManager.PlayAudio("Button Press");
        Application.Quit();
    }
}
