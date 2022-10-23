using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject lowPrefab;
    [SerializeField]
    private GameObject midPrefab;
    [SerializeField]
    private GameObject highSpawn;

    [SerializeField]
    private float spawnRateLow = 5f;

    [SerializeField]
    private float spawnRateHigh = 10f;

    private bool spawning;

    private void Start()
    {
        spawning = false;
    }
    private void FixedUpdate()
    {
        if (transform.childCount == 0 && !spawning)
        {
            StartCoroutine(SpawnCandy());
        }
    }

    private IEnumerator SpawnCandy()
    {
        spawning = true;

        yield return new WaitForSeconds(Random.Range(spawnRateLow, spawnRateLow));

        int randNum = Random.Range(0, 100);

        if (randNum < 70)
        {
            Instantiate(lowPrefab, transform);
        }
        else if (randNum < 98)
        {
            Instantiate(midPrefab, transform);
        }
        else
        {
            Instantiate(highSpawn, transform);
        }

        spawning = false;
    }
}
