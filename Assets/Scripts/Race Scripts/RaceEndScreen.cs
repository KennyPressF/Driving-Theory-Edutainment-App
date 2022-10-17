using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class RaceEndScreen : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI headerText;
    [SerializeField] GameObject star1;
    [SerializeField] GameObject star2;
    [SerializeField] GameObject star3;
    [SerializeField] Sprite[] possibleStarSprites;
    [SerializeField] TextMeshProUGUI awardedCoins;
    [SerializeField] Slider playerFuelSlider;

    Image star1Image;
    Image star2Image;
    Image star3Image;

    RaceManager raceManager;

    private void Awake()
    {
        raceManager = FindObjectOfType<RaceManager>();

        star1Image = star1.GetComponent<Image>();
        star2Image = star2.GetComponent<Image>();
        star3Image = star3.GetComponent<Image>();
    }

    void Start()
    {
        ShowFinalHeaderText();
        ShowStarRating();
        ShowCoinsCollectedThisRace();
    }

    private void ShowFinalHeaderText()
    {
        if (playerFuelSlider.value >= 750) { headerText.text = "Amazing!"; }
        else if (playerFuelSlider.value >= 500) { headerText.text = "Well Done"; }
        else if (playerFuelSlider.value >= 250) { headerText.text = "Not Bad"; }
        else if (playerFuelSlider.value >= 0) { headerText.text = "Try Again"; }
    }

    private void ShowStarRating()
    {
        if (playerFuelSlider.value >= 750) { star3Image.sprite = possibleStarSprites[1]; }
        if (playerFuelSlider.value >= 500) { star2Image.sprite = possibleStarSprites[1]; }
        if (playerFuelSlider.value >= 250) { star1Image.sprite = possibleStarSprites[1]; }
    }

    private void ShowCoinsCollectedThisRace()
    {
        awardedCoins.text = raceManager.coinsCollectedThisRace.ToString();
    }

}
