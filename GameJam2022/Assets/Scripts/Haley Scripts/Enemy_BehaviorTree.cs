using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_BehaviorTree : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private int playerDistance;
    private const float stunDelay = 5;    
    private NavMeshAgent agent;
    private bool stun = false;
    private float stunTime = 0;

    
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    
    void FixedUpdate()
    {
        if (!stun) {
            if (Vector3.Distance(transform.position, player.transform.position) < playerDistance) {
                seek(player.transform.position);
            } else {
                wander();
            }   

        } else {
            //Debug.Log(Time.realtimeSinceStartup);
            if (stunTime < Time.realtimeSinceStartup) {
                stun = false;
                Debug.Log("Stun Done");
            }                
        }
        
    }

    private void seek(Vector3 location)
    {
        //seeking = true;
        agent.SetDestination(location);

    }

    private void wander()
    {
        Vector3 wanderTarget = Vector3.zero;
        float wanderRadius = 20;
        float wanderDistance = 10;
        float wanderJitter = 1;

        wanderTarget += new Vector3(Random.Range(-1.0f, 1.0f) * wanderJitter, 0, Random.Range(-1.0f, 1.0f) * wanderJitter);
        wanderTarget.Normalize();
        wanderTarget *= wanderRadius;

        Vector3 targetLocal = wanderTarget + new Vector3(0, 0, wanderDistance);
        Vector3 targetWorld = gameObject.transform.InverseTransformVector(targetLocal);

        seek(targetWorld);

    }

    public void setStun()
    {
        if (!stun) {
            stun = true;
            stunTime = Time.realtimeSinceStartup + (stunDelay);
            Debug.Log("Stunned till " + stunTime + "\nCurrent time: " + Time.realtimeSinceStartup);
        }
        
    }

}
