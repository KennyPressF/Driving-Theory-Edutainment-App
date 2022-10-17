using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] pickups;

    private void Start()
    {
        StartCoroutine(WaitBeforeSpawn());
        StartCoroutine(WaitBeforeDestroy());
    }

    IEnumerator WaitBeforeSpawn()
    {
        float randomSpawnWaitTime = Random.Range(0.25f, 1.25f);
        yield return new WaitForSecondsRealtime(randomSpawnWaitTime);
        SpawnPickup();
    }

    private void SpawnPickup()
    {
        int randomPickup = Random.Range(0, pickups.Length);
        GameObject newPickup = Instantiate(pickups[randomPickup], transform.position, Quaternion.Euler(0f, 0f, 0f));
    }

    IEnumerator WaitBeforeDestroy()
    {
        yield return new WaitForSecondsRealtime(7f);
        Destroy(transform.parent.gameObject);
    }
}
