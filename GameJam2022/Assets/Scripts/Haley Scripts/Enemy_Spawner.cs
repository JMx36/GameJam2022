using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Spawner : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    [SerializeField] private float minTime = 5;
    [SerializeField] private float maxTime = 30;
    [SerializeField] private float cdTime = 15;
    private bool spawn = false;
    private float spawnTime = 0;
    private bool cd = false;
    

    private void Update()
    {
        if (spawn) {
            if (spawnTime < Time.realtimeSinceStartup) {
                Instantiate(enemy, transform.position, Quaternion.identity);
                spawn = false;
                cd = true;
                cdTime = Time.realtimeSinceStartup + cdTime;
            }
        }

        if (cd) {
            if (cdTime < Time.realtimeSinceStartup) {
                cd = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player") && !spawn && !cd) {
            spawn = true;
            spawnTime = Time.realtimeSinceStartup + Random.Range(minTime, maxTime);
        }
    }
}
