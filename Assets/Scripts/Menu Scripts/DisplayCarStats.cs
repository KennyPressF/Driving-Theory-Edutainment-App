using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class DisplayCarStats : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI carNameText;
    [SerializeField] List<CarStatsSO> carStatsList;
    [SerializeField] Slider durabilityStatSlider;
    [SerializeField] Slider fuelCapacityStatSlider;
    [SerializeField] Slider handlingStatSlider;

    CarStatsSO carStatsSO;
    GameManager gameManager;
    MainMenu mainMenu;
    AudioManager audioManager;

    int chosenCarIndex;
    public int upgradeCost;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        mainMenu = FindObjectOfType<MainMenu>();
        audioManager = FindObjectOfType<AudioManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        UpdateCarStatsDisplay();
    }

    public void UpdateCarStatsDisplay()
    {
        DisplayCarName();
        DisplayCarDurability();
        DisplayCarFuelCapacity();
        DisplayCarHandling();
    }

    private void DisplayCarName()
    {
        chosenCarIndex = PlayerPrefs.GetInt("Player Car");
        carStatsSO = carStatsList[chosenCarIndex];
        carNameText.text = carStatsSO.GetCarName();
    }

    private void DisplayCarDurability()
    {
        chosenCarIndex = PlayerPrefs.GetInt("Player Car");
        carStatsSO = carStatsList[chosenCarIndex];
        durabilityStatSlider.value = carStatsSO.GetCarDurability();
        PlayerPrefs.SetInt("Car Durability", carStatsSO.GetCarDurability());
    }

    public void IncreaseCarDurability()
    {
        int carDurability = carStatsSO.GetCarDurability();
        int currentPlayerCoins = PlayerPrefs.GetInt("Player Coins");

        if (carDurability < 10 && currentPlayerCoins >= upgradeCost)
        {
            audioManager.PlayAudio("Purchase");
            gameManager.SpendCoins(upgradeCost);
            mainMenu.UpdateResources();
            carStatsSO.UpgradeCarDurability();
            DisplayCarDurability();
        }

        else if (carDurability < 10 && currentPlayerCoins < upgradeCost)
        {
            Debug.Log("Too expensive bruh");
        }

        else if (carDurability >= 10)
        {
            Debug.Log("Stat already at the max!");
        }
    }

    private void DisplayCarFuelCapacity()
    {
        chosenCarIndex = PlayerPrefs.GetInt("Player Car");
        carStatsSO = carStatsList[chosenCarIndex];
        fuelCapacityStatSlider.value = carStatsSO.GetCarFuelCapacity();
        PlayerPrefs.SetInt("Car Fuel Capacity", carStatsSO.GetCarFuelCapacity());
    }
    public void IncreaseCarFuelCapacity()
    {
        int carFuelCapacity = carStatsSO.GetCarFuelCapacity();
        int currentPlayerCoins = PlayerPrefs.GetInt("Player Coins");

        if (carFuelCapacity < 10 && currentPlayerCoins >= upgradeCost)
        {
            audioManager.PlayAudio("Purchase");
            gameManager.SpendCoins(upgradeCost);
            mainMenu.UpdateResources();
            carStatsSO.UpgradeCarFuelCapacity();
            DisplayCarFuelCapacity();
        }

        else if (carFuelCapacity < 10 && currentPlayerCoins < upgradeCost)
        {
            Debug.Log("Too expensive bruh");
        }

        else if (carFuelCapacity >= 10)
        {
            Debug.Log("Stat already at the max!");
        }
    }

    private void DisplayCarHandling()
    {
        chosenCarIndex = PlayerPrefs.GetInt("Player Car");
        carStatsSO = carStatsList[chosenCarIndex];
        handlingStatSlider.value = carStatsSO.GetCarHandling();
        PlayerPrefs.SetInt("Car Handling", carStatsSO.GetCarHandling());
    }

    public void IncreaseCarHandling()
    {
        int carHandling = carStatsSO.GetCarHandling();
        int currentPlayerCoins = PlayerPrefs.GetInt("Player Coins");

        if (carHandling < 10 && currentPlayerCoins >= upgradeCost)
        {
            audioManager.PlayAudio("Purchase");
            gameManager.SpendCoins(upgradeCost);
            mainMenu.UpdateResources();
            carStatsSO.UpgradeCarHandling();
            DisplayCarHandling();
        }

        else if (carHandling < 10 && currentPlayerCoins < upgradeCost)
        {
            Debug.Log("Too expensive bruh");
        }

        else if (carHandling >= 10)
        {
            Debug.Log("Stat already at the max!");
        }
    }
}
