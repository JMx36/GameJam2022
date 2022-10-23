using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSee : MonoBehaviour
{
    [HideInInspector]
    public bool seePlayer = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
            seePlayer = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
            seePlayer = false;
    }
}
