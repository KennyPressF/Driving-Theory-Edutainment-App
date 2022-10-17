using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class RaceLevelLoader : MonoBehaviour
{
    [SerializeField] int raceLevelIndex;
    [SerializeField] int currentStars;
    [SerializeField] int starsNeededToUnlock;
    [SerializeField] Image levelLockedImage;
    [SerializeField] TextMeshProUGUI starsNeededText;
    [SerializeField] TextMeshProUGUI levelNumberText;
    [SerializeField] bool levelIsLocked = true;

    GameManager gameManager;
    MainMenu mainMenu;
    AudioManager audioManager;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        mainMenu = FindObjectOfType<MainMenu>();
        audioManager = FindObjectOfType<AudioManager>();
    }

    private void Start()
    {
        currentStars = PlayerPrefs.GetInt("Player Stars");

        levelNumberText.text = raceLevelIndex.ToString();
        starsNeededText.text = starsNeededToUnlock.ToString();

        if (currentStars >= starsNeededToUnlock)
        {
            levelIsLocked = false;
            levelLockedImage.gameObject.SetActive(false);
        }
    }

    public void LoadRaceLevel()
    {
        if (levelIsLocked == false && gameManager.playerEnergy > 0)
        {
            gameManager.SpendEnergy();
            mainMenu.UpdateResources();
            audioManager.StopAudio("Main Theme");
            audioManager.PlayAudio("Level Select");
            StartCoroutine(LoadRaceDelay());
        }

        else if ((levelIsLocked == false && gameManager.playerEnergy <= 0))
        {
            audioManager.PlayAudio("Button Press");
            mainMenu.ShowEnergyNeededCanvas();
        }
    }

    IEnumerator LoadRaceDelay()
    {
        float waitBeforeLoad = audioManager.GetWaitTime("Level Select");
        yield return new WaitForSeconds(waitBeforeLoad);
        SceneManager.LoadScene(raceLevelIndex);
        Debug.Log("This is scene:" + raceLevelIndex);
    }
}
