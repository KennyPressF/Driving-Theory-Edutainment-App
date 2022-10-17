using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatternSpawner : MonoBehaviour
{
    [SerializeField] float timeBetweenSpawns;
    [SerializeField] float startTimeBetweenSpawns;
    [SerializeField] GameObject[] patternArray;

    // Update is called once per frame
    void Update()
    {
        if (timeBetweenSpawns <= 0)
        {
            int randomPattern = Random.Range(0, patternArray.Length);
            Instantiate(patternArray[randomPattern], transform.position, Quaternion.identity);
            timeBetweenSpawns = startTimeBetweenSpawns;
        }

        else
        {
            timeBetweenSpawns -= Time.deltaTime;
        }
    }
}
