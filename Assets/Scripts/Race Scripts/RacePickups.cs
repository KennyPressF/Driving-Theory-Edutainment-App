using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RacePickups : MonoBehaviour
{
    [SerializeField] float moveSpeed = 2f;
    [SerializeField] float rotationSpeed;
    [SerializeField] float fuelPickupValue;
    [SerializeField] int raceCoinValue;

    RacePlayer racePlayer;
    RaceManager raceManager;
    GameManager gameManager;
    AudioManager audioManager;
    Rigidbody myRigidBody;

    private void Awake()
    {
        racePlayer = FindObjectOfType<RacePlayer>();
        raceManager = FindObjectOfType<RaceManager>();
        gameManager = FindObjectOfType<GameManager>();
        audioManager = FindObjectOfType<AudioManager>();

        myRigidBody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        transform.position = new Vector2(transform.position.x, transform.position.y - moveSpeed * Time.deltaTime);
        myRigidBody.transform.Rotate(new Vector3(0f, 0f, rotationSpeed));
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player") && raceManager.raceFinished == false)
        {
            if (gameObject.CompareTag("L Plate"))
            {
                audioManager.PlayAudio("L Plate Pickup");
                raceManager.UpdateLPlatesCounter();
                Destroy(gameObject);
            }

            else if (gameObject.CompareTag("Fuel Refill"))
            {
                audioManager.PlayAudio("Fuel Pickup");
                racePlayer.RefillFuel(fuelPickupValue);
                Destroy(gameObject);
            }

            else if (gameObject.CompareTag("Coin"))
            {
                audioManager.PlayAudio("Coin Pickup");
                raceManager.coinsCollectedThisRace++;
                gameManager.AddToCoins(raceCoinValue);
                Destroy(gameObject);
            }
        }

        else if (collision.CompareTag("Shredder"))
        {
            Destroy(gameObject);
        }
    }
}
