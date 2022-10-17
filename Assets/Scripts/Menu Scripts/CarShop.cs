using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class CarShop : MonoBehaviour
{
    [SerializeField] Canvas carShopCanvas;
    [SerializeField] TextMeshProUGUI carCostText;
    [SerializeField] List<CarStatsSO> carStatsList;
    [SerializeField] List<GameObject> lockedSymbolList;
    [SerializeField] Button purchaseButton;
    [SerializeField] Button confirmPurchaseButton;
    [SerializeField] Button levelSelectorButton;
    [SerializeField] GameObject levelLockImage;
    [SerializeField] Button durabilityUpgradeButton;
    [SerializeField] Button fuelUpgradeButton;
    [SerializeField] Button handlingUpgradeButton;

    int chosenCarIndex;
    int playerCurrentCoins;
    int carCost;

    CarStatsSO carStatsSO;
    GameObject lockedSymbol;
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
        levelSelectorButton = levelSelectorButton.GetComponent<Button>();
        CheckIfCarIsUnlocked();
    }

    public void CheckIfCarIsUnlocked()
    {
        chosenCarIndex = PlayerPrefs.GetInt("Player Car");
        carStatsSO = carStatsList[chosenCarIndex];

        if (carStatsSO.carIsUnlocked == true)
        {
            purchaseButton.gameObject.SetActive(false);
            levelSelectorButton.enabled = true;
            levelLockImage.gameObject.SetActive(false);

            durabilityUpgradeButton.interactable = true;
            fuelUpgradeButton.interactable = true;
            handlingUpgradeButton.interactable = true;
        }

        else if (carStatsSO.carIsUnlocked == false)
        {
            purchaseButton.gameObject.SetActive(true);
            levelSelectorButton.enabled = false;
            levelLockImage.gameObject.SetActive(true);

            durabilityUpgradeButton.interactable = false;
            fuelUpgradeButton.interactable = false;
            handlingUpgradeButton.interactable = false;
        }
    }

    public void ShowCarShopCanvas()
    {
        carShopCanvas.gameObject.SetActive(true);
        audioManager.PlayAudio("Button Press");

        playerCurrentCoins = PlayerPrefs.GetInt("Player Coins");
        chosenCarIndex = PlayerPrefs.GetInt("Player Car");
        carStatsSO = carStatsList[chosenCarIndex];
        carCost = carStatsSO.GetCarCost();

        carCostText.text = carCost.ToString();

        if (playerCurrentCoins < carCost)
        {
            carCostText.color = Color.red;
        }
    }

    public void UnlockCar()
    {
        playerCurrentCoins = PlayerPrefs.GetInt("Player Coins");
        chosenCarIndex = PlayerPrefs.GetInt("Player Car");

        carStatsSO = carStatsList[chosenCarIndex];
        carCost = carStatsSO.GetCarCost();

        if (playerCurrentCoins >= carCost)
        {
            audioManager.PlayAudio("Purchase");
            gameManager.SpendCoins(carCost);
            mainMenu.UpdateResources();

            carStatsSO.carIsUnlocked = true;

            lockedSymbol = lockedSymbolList[chosenCarIndex];
            lockedSymbol.gameObject.SetActive(false);

            CheckIfCarIsUnlocked();
            carShopCanvas.gameObject.SetActive(false);
        }
    }
}
