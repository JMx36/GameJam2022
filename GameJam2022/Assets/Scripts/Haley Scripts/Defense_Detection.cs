using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defense_Detection : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        stun(other);
    }

    private void OnTriggerEnter(Collider other)
    {
        stun(other);
    }

    private void OnTriggerExit(Collider other)
    {
        stun(other);
    }

    private void stun(Collider other)
    {
        Enemy_BehaviorTree BehaviorTree = other.gameObject.GetComponent<Enemy_BehaviorTree>();
        if (BehaviorTree != null && Input.GetKeyDown(KeyCode.F)) {
            BehaviorTree.setStun();
        }
    }

}
