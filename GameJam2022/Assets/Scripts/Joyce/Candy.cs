using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Candy : MonoBehaviour
{
    private static GameStateManager gm;
    private Transform cam;

    [SerializeField]
    private bool faceCam = true;

    [SerializeField]
    private int point;

    void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera").transform;
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameStateManager>();
    }
    void Update()
    {
        if (faceCam)
        {
            transform.LookAt(cam);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            print("candy triggered");
            gm.AddPoints(point);
            Destroy(gameObject);
        }
    }
}
