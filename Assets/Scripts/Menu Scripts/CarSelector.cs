using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSelector : MonoBehaviour
{
    [SerializeField] float scrollSpeed;
    [SerializeField] Vector3[] positions;

    int chosenCarIndex;
    int carDurability;

    Vector2 newCarPosition;

    DisplayCarStats displayCarStats;
    CarShop carShop;
    AudioManager audioManager;

    private void Awake()
    {
        displayCarStats = FindObjectOfType<DisplayCarStats>();
        carShop = FindObjectOfType<CarShop>();
        audioManager = FindObjectOfType<AudioManager>();
    }

    private void Start()
    {
        chosenCarIndex = PlayerPrefs.GetInt("Player Car", chosenCarIndex);
        transform.position = positions[chosenCarIndex];
        newCarPosition = transform.position;
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, newCarPosition, scrollSpeed * Time.deltaTime);
    }

    public void NextCar()
    {
        if (chosenCarIndex < positions.Length - 1)
        {
            chosenCarIndex++;
            audioManager.PlayAudio("Car Select");
            newCarPosition = positions[chosenCarIndex];
            PlayerPrefs.SetInt("Player Car", chosenCarIndex);
            carShop.CheckIfCarIsUnlocked();
            displayCarStats.UpdateCarStatsDisplay();
        }
    }

    public void PreviousCar()
    {
        if (chosenCarIndex > 0)
        {
            chosenCarIndex--;
            audioManager.PlayAudio("Car Select");
            newCarPosition = positions[chosenCarIndex];
            PlayerPrefs.SetInt("Player Car", chosenCarIndex);
            carShop.CheckIfCarIsUnlocked();
            displayCarStats.UpdateCarStatsDisplay();
        }
    }
}
