using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseManager : MonoBehaviour
{
    [SerializeField]
    private Color lowCol;
    [SerializeField]
    private GameObject lowSpawn;

    [SerializeField]
    private Color midCol;
    [SerializeField]
    private GameObject midSpawn;

    [SerializeField]
    private Color highCol;
    [SerializeField]
    private GameObject highSpawn;


    [SerializeField]
    private GameObject enemySpawn;


    [SerializeField]
    private List<House> houses;

    [SerializeField]
    private int lowHouses = 5;

    [SerializeField]
    private int midHouses = 3;

    [SerializeField]
    private int highHouses = 3;

    [SerializeField]
    private float spawnPeriod = 60;

    private List<int> takenHouses = new List<int>();


    void Start()
    {
        List<int> takenHouses = new List<int>();
        StartCoroutine(PickHouses());
    }

    private IEnumerator PickHouses()
    {
        while (true)
        {
            List<int> takenHouses = new List<int>();

            SetHouses(lowHouses, lowCol, lowSpawn);
            SetHouses(midHouses, midCol, midSpawn);
            SetHouses(highHouses, highCol, highSpawn);

            yield return new WaitForSeconds(spawnPeriod);
        }
    }
    private void SetHouses(int numHouses, Color lightCol, GameObject spawn, bool safe = false)
    {
        int i = 0;

        while (i < numHouses)
        {
            int index = Random.Range(0, houses.Count);
            if (!takenHouses.Contains(index))
            {
                houses[index].LightsOn(lightCol);
                houses[index].SetSpawn(spawn);

                if (safe)
                {
                    houses[index].SpawnCandy();
                }
            }
        }


    }
}
