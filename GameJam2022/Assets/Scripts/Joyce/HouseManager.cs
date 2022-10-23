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
    private GameObject enemyPrefab;


    [SerializeField]
    private List<House> houses;

    [SerializeField]
    private int lowHouses = 5;

    [SerializeField]
    private int midHouses = 3;

    [SerializeField]
    private int highHouses = 3;

    [SerializeField]
    private float spawnPeriod = 120;

    private List<int> takenHouses;


    void Start()
    {
        takenHouses = new List<int>();
        StartCoroutine(PickHouses());
    }

    private IEnumerator PickHouses()
    {
        while (true)
        {
            ResetHouses();
            takenHouses.Clear();

            SetHouses(lowHouses, lowCol, lowSpawn, 1);
            SetHouses(midHouses, midCol, midSpawn, 2);
            SetHouses(highHouses, highCol, highSpawn, 3);

            yield return new WaitForSeconds(spawnPeriod);
        }
    }
    private void SetHouses(int numHouses, Color lightCol, GameObject spawn, int level)
    {
        int i = 1;

        while (i <= numHouses)
        {
            int index = Random.Range(0, houses.Count);
            if (!takenHouses.Contains(index))
            {
                houses[index].LightsOn(lightCol);
                houses[index].SetSpawn(spawn);
                houses[index].SetLevel(level);

                if (level == 1)
                {
                    houses[index].Spawn();
                }
                else
                {
                    int randNum = Random.Range(0, 2);

                    if(randNum == 0)
                    {
                        houses[index].SetSpawn(enemyPrefab);
                        houses[index].Spawn();
                    }
                }

                takenHouses.Add(index);

                i++;
            }
        }

    }

    private void ResetHouses()
    {
        foreach (House house in houses)
        {
            house.LightsOff();
            house.Despawn();
        }
    }
}
