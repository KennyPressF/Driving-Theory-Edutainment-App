using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] int playerCoins;
    [SerializeField] public int playerEnergy;
    [SerializeField] int maxEnergy;
    [SerializeField] int playerStars;


    private void Awake()
    {
        SetUpGameManagerSingleton();
        SetDefaultPlayerPrefs();
    }

    private void SetUpGameManagerSingleton()
    {
        int numberOfGameManagers = FindObjectsOfType<GameManager>().Length;

        if (numberOfGameManagers > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public int DisplayCoins()
    {
        return playerCoins;
    }

    public void AddToCoins(int coinValue)
    {
        playerCoins += coinValue;
        PlayerPrefs.SetInt("Player Coins", playerCoins);
    }

    public void SpendCoins(int spendCost)
    {
        playerCoins -= spendCost;
        PlayerPrefs.SetInt("Player Coins", playerCoins);
    }

    public int DisplayEnergy()
    {
        return playerEnergy;
    }

    public void AddToEnergy()
    {
        if (playerEnergy < maxEnergy)
        {
            playerEnergy++;
            PlayerPrefs.SetInt("Player Energy", playerEnergy);
        }

        else
        {
            Debug.Log("Already at max energy");
        }
    }

    public void SpendEnergy()
    {
        if (playerEnergy > 0)
        {
            playerEnergy--;
            PlayerPrefs.SetInt("Player Energy", playerEnergy);
        }

        else
        {
            Debug.Log("Insufficient energy");
        }
    }

    public int DisplayStars()
    {
        return playerStars;
    }

    public void AddToStars(int starsToAdd)
    {
        playerStars += starsToAdd;
        PlayerPrefs.SetInt("Player Stars", playerStars);
    }

    private void SetDefaultPlayerPrefs()
    {
        if (!PlayerPrefs.HasKey("Player Coins"))
        {
            PlayerPrefs.SetInt("Player Coins", 0);
        }

        else
        {
            playerCoins = PlayerPrefs.GetInt("Player Coins");
        }

        if (!PlayerPrefs.HasKey("Player Stars"))
        {
            PlayerPrefs.SetInt("Player Stars", 0);
        }

        else
        {
            playerStars = PlayerPrefs.GetInt("Player Stars");
        }

        if (!PlayerPrefs.HasKey("Player Energy"))
        {
            PlayerPrefs.SetInt("Player Energy", maxEnergy);
        }

        else
        {
            playerEnergy = PlayerPrefs.GetInt("Player Energy");
        }
    }
}
