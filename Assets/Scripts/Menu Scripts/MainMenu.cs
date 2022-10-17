using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainMenu : MonoBehaviour
{
    [Header("Resources")]
    [SerializeField] TextMeshProUGUI playerCoinsDisplay;
    [SerializeField] TextMeshProUGUI playerEnergyDisplay;
    [SerializeField] TextMeshProUGUI playerStarsDisplay;

    [Header("Canvases")]
    [SerializeField] Canvas levelSelectorCanvas;
    [SerializeField] Canvas quizSelectorCanvas;
    [SerializeField] Canvas revisionCanvas;
    [SerializeField] Canvas settingsCanvas;
    [SerializeField] Canvas upgradeShopCanvas;
    [SerializeField] Canvas carShopCanvas;
    [SerializeField] Canvas energyNeededCanvas;

    GameManager gameManager;
    AudioManager audioManager;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        audioManager = FindObjectOfType<AudioManager>();

        levelSelectorCanvas.gameObject.SetActive(false);
        quizSelectorCanvas.gameObject.SetActive(false);
        revisionCanvas.gameObject.SetActive(false);
        settingsCanvas.gameObject.SetActive(false);
        upgradeShopCanvas.gameObject.SetActive(false);
        carShopCanvas.gameObject.SetActive(false);
        energyNeededCanvas.gameObject.SetActive(false);
    }

    void Start()
    {
        audioManager.PlayAudio("Main Theme");
        UpdateResources();
    }

    public void UpdateResources()
    {
        playerCoinsDisplay.text = gameManager.DisplayCoins().ToString();
        playerEnergyDisplay.text = gameManager.DisplayEnergy().ToString();
        playerStarsDisplay.text = gameManager.DisplayStars().ToString();
    }

    public void ShowLevelSelectorCanvas()
    {
        audioManager.PlayAudio("Button Press");
        levelSelectorCanvas.gameObject.SetActive(true);
    }

    public void HideLevelSelectorCanvas()
    {
        audioManager.PlayAudio("Button Press");
        levelSelectorCanvas.gameObject.SetActive(false);
    }

    public void ShowQuizSelectorCanvas()
    {
        audioManager.PlayAudio("Button Press");
        quizSelectorCanvas.gameObject.SetActive(true);
    }

    public void HideQuizSelectorCanvas()
    {
        audioManager.PlayAudio("Button Press");
        quizSelectorCanvas.gameObject.SetActive(false);
    }

    public void ShowRevisionCanvas()
    {
        audioManager.PlayAudio("Button Press");
        revisionCanvas.gameObject.SetActive(true);
    }

    public void HideRevisionCanvas()
    {
        audioManager.PlayAudio("Button Press");
        revisionCanvas.gameObject.SetActive(false);
    }

    public void ShowSettingsCanvas()
    {
        audioManager.PlayAudio("Button Press");
        settingsCanvas.gameObject.SetActive(true);
    }

    public void HideSettingsCanvas()
    {
        audioManager.PlayAudio("Button Press");
        settingsCanvas.gameObject.SetActive(false);
    }

    public void HideUpgradeShopCanvas()
    {
        audioManager.PlayAudio("Button Press");
        upgradeShopCanvas.gameObject.SetActive(false);
    }

    public void HideCarShopCanvas()
    {
        audioManager.PlayAudio("Button Press");
        carShopCanvas.gameObject.SetActive(false);
    }

    public void ShowEnergyNeededCanvas()
    {
        audioManager.PlayAudio("Button Press");
        energyNeededCanvas.gameObject.SetActive(true);
    }

    public void HideEnergyNeededCanvas()
    {
        audioManager.PlayAudio("Button Press");
        energyNeededCanvas.gameObject.SetActive(false);
    }
}
