using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RacePlayer : MonoBehaviour
{
    [Header("Spawn Settings")]
    [SerializeField] GameObject[] playerCarArray;
    [SerializeField] Vector3 playerSize;
    [SerializeField] Vector2 targetPosition;

    [Header("Movement Settings")]
    [SerializeField] float moveAmount;
    [SerializeField] float moveSpeed;
    [SerializeField] float maxXValue;
    [SerializeField] float minXValue;

    [Header("Player Settings")]
    [SerializeField] public int playerLives;
    [SerializeField] int playerFuel;
    [SerializeField] Slider fuelSlider;
    [SerializeField] int playerHandling;

    int chosenCar;
    public bool playerIsAlive;

    float moveX1;
    float moveX2;
    int moveCounter;

    RaceManager raceManager;
    AudioManager audioManager;
    Image fuelSliderColour;

    private void Awake()
    {
        raceManager = FindObjectOfType<RaceManager>();
        audioManager = FindObjectOfType<AudioManager>();
        fuelSliderColour = fuelSlider.fillRect.GetComponent<Image>();
    }

    void Start()
    {   
        targetPosition = transform.position;
        SpawnPlayer();
        SetPlayerStats();
        audioManager.PlayAudio("Car Engine");
        playerIsAlive = true;
    }

    void Update()
    {
        if (playerIsAlive)
        {
            Move();
            ConsumeFuel();
        }    
    }

    private void SpawnPlayer()
    {
        chosenCar = PlayerPrefs.GetInt("Player Car");
        GameObject playerCar = Instantiate(playerCarArray[chosenCar], transform.position, Quaternion.Euler(-90f, 0f, 0f));
        playerCar.transform.localScale = playerSize;
        playerCar.transform.parent = gameObject.transform;
    }

    private void SetPlayerStats()
    {
        playerLives = PlayerPrefs.GetInt("Car Durability");
        playerFuel = PlayerPrefs.GetInt("Car Fuel Capacity");
        playerHandling = PlayerPrefs.GetInt("Car Handling");
    }

    private void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        if (Input.GetMouseButtonDown(0)) { moveX1 = Input.mousePosition.x; }

        if (Input.GetMouseButtonUp(0))
        {
            moveX2 = Input.mousePosition.x;

            if (moveX1 > moveX2 && transform.position.x > minXValue + 0.01)
            {
                targetPosition = new Vector2(transform.position.x - moveAmount, transform.position.y);
            }

            if (moveX2 > moveX1 && transform.position.x > minXValue - 0.01)
            {
                targetPosition = new Vector2(transform.position.x + moveAmount, transform.position.y);
            }
        }
    }

    public void LoseLife()
    {
        if (playerIsAlive)
        {
            if (playerLives > 1)
            {
                playerLives--;
                Debug.Log("Lives remaining:" + playerLives);
                raceManager.UpdatePlayerLivesCounter();
            }

            else
            {
                playerLives = 0;
                playerIsAlive = false;
                raceManager.UpdatePlayerLivesCounter();
                raceManager.RaceFailed();
            }
        }
    }

    private void ConsumeFuel()
    {
        if (fuelSlider.value <= 0)
        {
            playerIsAlive = false;
            raceManager.RaceFailed();
        }

        else
        {
            float fuelConsumptionRate = 15 - playerFuel;
            fuelSlider.value -= fuelConsumptionRate * Time.deltaTime;
            UpdateFuelSliderColour();
        }        
    }

    public void RefillFuel(float fuelPickupValue)
    {
        fuelSlider.value += fuelPickupValue;
    }

    private void UpdateFuelSliderColour()
    {
        if (fuelSlider.value >= 750) { fuelSliderColour.color = Color.green; }
        if (fuelSlider.value < 750 && fuelSlider.value >= 500) { fuelSliderColour.color = Color.yellow; }
        if (fuelSlider.value < 500 && fuelSlider.value >= 250) { fuelSliderColour.color = new Color(1.0f, 0.64f, 0.0f); } //(orange)
        if (fuelSlider.value < 250) { fuelSliderColour.color = Color.red; }
    }

}
