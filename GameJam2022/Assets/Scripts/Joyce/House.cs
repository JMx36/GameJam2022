using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : MonoBehaviour
{
    [SerializeField]
    private GameObject spot;
    [SerializeField]
    private GameObject point;

    [SerializeField]
    private Transform spawnPoint;

    private GameObject spawn;
    private bool lightsOn = false;

    private bool canSpawnCandy = false;
    [SerializeField]
    private float candyCooldown = 60f;



    private enum Level {SAFE, MID, DANGER}
    private Level level;

    public void LightsOn(Color col)
    {
        lightsOn = true;
        canSpawnCandy = true;

        spot.SetActive(true);
        point.SetActive(true);
        spot.GetComponent<Light>().color = col;
        point.GetComponent<Light>().color = col;
    }

    public void LightsOff()
    {
        lightsOn = false;
        canSpawnCandy = false;

        spot.SetActive(false);
        point.SetActive(false);
    }

    public void Spawn()
    {
        Instantiate(spawn, spawnPoint);
    }

    public void Despawn()
    {
        if (spawnPoint.childCount > 0)
            Destroy(spawnPoint.GetChild(0).gameObject);
    }

    public void SetSpawn(GameObject prefab)
    {
        spawn = prefab;
    }
    public void SetLevel(int type)
    {
        if (type == 1)
        {
            level = Level.SAFE;
        }
        else if (type == 2)
        {
            level = Level.MID;
        }
        else
        {
            level = Level.DANGER;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {

            print("triggered");

            if (spawnPoint.childCount == 0 && lightsOn && canSpawnCandy)
            {
                print("Should be candy");
                Spawn();
                StartCoroutine(CandyCooldown());
            }
        }
    }

    private IEnumerator CandyCooldown()
    {
        canSpawnCandy = false;
        yield return new WaitForSeconds(candyCooldown);
        canSpawnCandy = true;
    }
}
