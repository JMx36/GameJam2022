using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : MonoBehaviour
{
    [SerializeField]
    private Light spot;
    [SerializeField]
    private Light point;

    [SerializeField]
    private Transform candySpawn;

    private GameObject spawn;

    private void Start()
    {
        spot.enabled = false;
        point.enabled = false;
    }

    public void LightsOn( Color col)
    {
        spot.enabled = true;
        spot.color = col;
        point.enabled = true;
        point.color = col;
    }

    public void SpawnCandy()
    {
        Instantiate(spawn, candySpawn);
    }

    public void SetSpawn(GameObject prefab)
    {
        spawn = prefab;
    }
}
