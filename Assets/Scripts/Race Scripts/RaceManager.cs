using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RaceManager : MonoBehaviour
{
    [Header("L Plates")]
    [SerializeField] int currentLPlates;
    [SerializeField] int targetLPlates;
    [SerializeField] TextMeshProUGUI lPlatesCounterText;

    [Header("Lives")]
    [SerializeField] int currentPlayerLives;
    [SerializeField] int maxPlayerLives;
    [SerializeField] TextMeshProUGUI playerLivesText;

    [Header("Canvases")]
    [SerializeField] Canvas raceEndCanvas;
    [SerializeField] Canvas raceFailCanvas;
    [SerializeField] Slider playerFuelSlider;

    GameManager gameManager;
    RacePlayer racePlayer;
    AudioManager audioManager;

    int starsToAdd;
    public int coinsCollectedThisRace;
    public bool raceFinished;


    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        racePlayer = FindObjectOfType<RacePlayer>();
        audioManager = FindObjectOfType<AudioManager>();

        raceEndCanvas.gameObject.SetActive(false);
    }

    void Start()
    {
        raceFinished = false;

        coinsCollectedThisRace = 0;

        currentLPlates = 0;
        lPlatesCounterText.text = currentLPlates + "/" + targetLPlates;

        maxPlayerLives = PlayerPrefs.GetInt("Car Durability");
        currentPlayerLives = maxPlayerLives;
        playerLivesText.text = currentPlayerLives + "/" + maxPlayerLives;
    }
    private void Update()
    {
        CalculateStarsToAdd();
    }

    public void UpdateLPlatesCounter()
    {
        currentLPlates++;
        lPlatesCounterText.text = currentLPlates + "/" + targetLPlates;

        if (currentLPlates == targetLPlates)
        {
            RaceWon();
        }
    }

    public void UpdatePlayerLivesCounter()
    {
        currentPlayerLives = racePlayer.playerLives;
        playerLivesText.text = currentPlayerLives + "/" + maxPlayerLives;
    }

    public void RaceWon()
    {
        raceFinished = true;
        raceEndCanvas.gameObject.SetActive(true);
        audioManager.StopAudio("Car Engine");
        audioManager.PlayAudio("Level Complete");
        gameManager.AddToStars(starsToAdd);
        Debug.Log("Race Won!");
    }

    public void RaceFailed()
    {
        raceFinished = true;
        raceFailCanvas.gameObject.SetActive(true);
        audioManager.StopAudio("Car Engine");
        audioManager.PlayAudio("Player Death");
        Debug.Log("Race failed!");
    }

    private void CalculateStarsToAdd()
    {
        if (playerFuelSlider.value >= 750) { starsToAdd = 3; }
        else if (playerFuelSlider.value >= 500) { starsToAdd = 2; }
        else if (playerFuelSlider.value >= 250) { starsToAdd = 1; }
        else if (playerFuelSlider.value >= 0) { starsToAdd = 0; }
    }
}
