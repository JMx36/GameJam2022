using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Candy : MonoBehaviour
{
    private static GameStateManager gm;
    private Transform cam;

    [SerializeField]
    private int point;

    void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera").transform;
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameStateManager>();
    }
    void Update()
    {
        transform.LookAt(cam);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            gm.AddPoints(point);
            Destroy(gameObject);
        }
    }
}
