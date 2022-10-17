using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceObstacle : MonoBehaviour
{
    [SerializeField] float moveSpeed = 2f;
    [SerializeField] ParticleSystem explosionFX;

    RacePlayer racePlayer;
    RaceManager raceManager;
    AudioManager audioManager;

    private void Awake()
    {
        racePlayer = FindObjectOfType<RacePlayer>();
        raceManager = FindObjectOfType<RaceManager>();
        audioManager = FindObjectOfType<AudioManager>();
    }

    void Update()
    {
        transform.position = new Vector2(transform.position.x, transform.position.y - moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player") && raceManager.raceFinished == false)
        {
            racePlayer.LoseLife();
            if (racePlayer.playerLives >= 1) { audioManager.PlayAudio("Collision"); }
            Instantiate(explosionFX, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

        else if (collision.CompareTag("Shredder"))
        {
            Destroy(gameObject);
        }
    }
}
