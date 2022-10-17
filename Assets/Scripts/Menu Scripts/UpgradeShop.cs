using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradeShop : MonoBehaviour
{
    [SerializeField] Canvas upgradeShopCanvas;
    [SerializeField] TextMeshProUGUI statName;
    [SerializeField] TextMeshProUGUI currentStatLevelText;
    [SerializeField] TextMeshProUGUI nextStatLevelText;
    [SerializeField] TextMeshProUGUI upgradeCostText;
    [SerializeField] List<CarStatsSO> carStatsList;

    CarStatsSO carStatsSO;
    DisplayCarStats displayCarStats;
    AudioManager audioManager;

    int chosenCarIndex;
    int statToUpgrade; // 1 = durability, 2 = fuel capacity, 3 = handling
    int nextUpgradeCost;

    private void Awake()
    {
        displayCarStats = FindObjectOfType<DisplayCarStats>();
        audioManager = FindObjectOfType<AudioManager>();
    }

    public void UpgradeChosenStat()
    {
        if (statToUpgrade == 1) { displayCarStats.IncreaseCarDurability(); ShowDurabilityUpgrader(); }
        else if (statToUpgrade == 2) { displayCarStats.IncreaseCarFuelCapacity(); ShowFuelCapacityUpgrader(); }
        else if (statToUpgrade == 3) { displayCarStats.IncreaseCarHandling(); ShowHandlingUpgrader(); }
    }

    public void ShowDurabilityUpgrader()
    {
        audioManager.PlayAudio("Button Press");
        upgradeShopCanvas.gameObject.SetActive(true);
        chosenCarIndex = PlayerPrefs.GetInt("Player Car");
        statToUpgrade = 1;

        statName.text = "Durability:";
        carStatsSO = carStatsList[chosenCarIndex];

        int currentStatLevel = carStatsSO.GetCarDurability();
        int nextStatLevel = currentStatLevel + 1;
        
        currentStatLevelText.text = currentStatLevel.ToString();

        if (currentStatLevel < 10) { nextStatLevelText.text = nextStatLevel.ToString(); }
        else { nextStatLevelText.text = currentStatLevel.ToString(); }

        nextUpgradeCost = currentStatLevel * 10;
        displayCarStats.upgradeCost = nextUpgradeCost;
        upgradeCostText.text = nextUpgradeCost.ToString();

        if (PlayerPrefs.GetInt("Player Coins") < nextUpgradeCost)
        {
            upgradeCostText.color = Color.red;
        }
    }

    public void ShowFuelCapacityUpgrader()
    {
        audioManager.PlayAudio("Button Press");
        upgradeShopCanvas.gameObject.SetActive(true);
        chosenCarIndex = PlayerPrefs.GetInt("Player Car");
        statToUpgrade = 2;

        statName.text = "Fuel Capacity:";
        carStatsSO = carStatsList[chosenCarIndex];

        int currentStatLevel = carStatsSO.GetCarFuelCapacity();
        int nextStatLevel = currentStatLevel + 1;

        currentStatLevelText.text = currentStatLevel.ToString();

        if (currentStatLevel < 10) { nextStatLevelText.text = nextStatLevel.ToString(); }
        else { nextStatLevelText.text = currentStatLevel.ToString(); }

        nextUpgradeCost = currentStatLevel * 10;
        displayCarStats.upgradeCost = nextUpgradeCost;
        upgradeCostText.text = nextUpgradeCost.ToString();

        if (PlayerPrefs.GetInt("Player Coins") < nextUpgradeCost)
        {
            upgradeCostText.color = Color.red;
        }
    }

    public void ShowHandlingUpgrader()
    {
        audioManager.PlayAudio("Button Press");
        upgradeShopCanvas.gameObject.SetActive(true);
        chosenCarIndex = PlayerPrefs.GetInt("Player Car");
        statToUpgrade = 3;

        statName.text = "Handling:";
        carStatsSO = carStatsList[chosenCarIndex];

        int currentStatLevel = carStatsSO.GetCarHandling();
        int nextStatLevel = currentStatLevel + 1;

        currentStatLevelText.text = currentStatLevel.ToString();

        if (currentStatLevel < 10) { nextStatLevelText.text = nextStatLevel.ToString(); }
        else { nextStatLevelText.text = currentStatLevel.ToString(); }

        nextUpgradeCost = currentStatLevel * 10;
        displayCarStats.upgradeCost = nextUpgradeCost;
        upgradeCostText.text = nextUpgradeCost.ToString();

        if (PlayerPrefs.GetInt("Player Coins") < nextUpgradeCost)
        {
            upgradeCostText.color = Color.red;
        }
    }
}
