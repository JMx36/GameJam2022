using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandySpawner : MonoBehaviour
{
    [SerializeField]
    private List<Transform> spawnLocations;

    [SerializeField]
    private GameObject lowPrefab;
    [SerializeField]
    private GameObject midPrefab;
    [SerializeField]
    private GameObject highSpawn;

    [SerializeField]
    private float spawnRate = 5f;



    void Start()
    {
        StartCoroutine(SpawnCandy());
    }

    private IEnumerator SpawnCandy()
    {
        while (true) {

            Transform spawnLoc = null;

            while (!spawnLoc)
            {
                int index = Random.Range(0, spawnLocations.Count);

                if (spawnLocations[index].childCount == 0)
                {
                    spawnLoc = spawnLocations[index];
                    yield return new WaitForSeconds(spawnRate);
                }
            }

            int randNum = Random.Range(0, 100);

            if (randNum < 70)
            {
                Instantiate(lowPrefab, spawnLoc);
            }
            else if (randNum < 98)
            {
                Instantiate(midPrefab, spawnLoc);
            }
            else
            {
                Instantiate(highSpawn, spawnLoc);
            }
        }
    }
}
