using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] obstacles;

    private void Start()
    {
        StartCoroutine(WaitBeforeSpawn());
        StartCoroutine(WaitBeforeDestroy());    
    }

    IEnumerator WaitBeforeSpawn()
    {
        float randomSpawnWaitTime = Random.Range(0.25f, 1.25f);
        yield return new WaitForSecondsRealtime(randomSpawnWaitTime);
        SpawnObstacle();
    }

    private void SpawnObstacle()
    {
        int randomObstacle = Random.Range(0, obstacles.Length);
        GameObject newObstacle = Instantiate(obstacles[randomObstacle], transform.position, Quaternion.Euler(-90f, 0f, 0f));
        newObstacle.transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
    }

    IEnumerator WaitBeforeDestroy()
    {
        yield return new WaitForSecondsRealtime(7f);
        Destroy(transform.parent.gameObject);
    }
}
