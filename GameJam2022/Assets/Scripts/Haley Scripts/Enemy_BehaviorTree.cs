using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_BehaviorTree : MonoBehaviour
{
    //[SerializeField] private int playerDistance;
    private GameObject player;
    private NavMeshAgent agent;
    private Movement move;

    private const float stunDelay = 5f;
    private bool stun = false;
    private float stunTime = 0f;

    [SerializeField] private const float stealDist = 3f;
    [SerializeField]private float stealCD = 5f;
    private float stealTime = 0f;
    private int stealAmount = 1;

    static public int CANDY = 10; // FILLER VARIABLE

    
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
        move = player.GetComponent<Movement>();
    }

    
    void FixedUpdate()
    {
        if (!stun) {

            if (canSeeTarget()) {
                
                if (Vector3.Distance(transform.position, player.transform.position) < stealDist) {
                    stealCandy();
                } else {
                    seek(player.transform.position);
                }
                
            } else {
                wander();
            }   

        } else {

            if (stunTime < Time.realtimeSinceStartup) {
                stun = false;
                Debug.Log("Stun Done");
            }
            
        }
        
    }

    private void seek(Vector3 location)
    {
        agent.SetDestination(location);

    }

    
    private void wander()
    {
        Vector3 wanderTarget = Vector3.zero;
        float wanderRadius = 10;
        float wanderDistance = 20;
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
            seek(transform.position);
            stunTime = Time.realtimeSinceStartup + (stunDelay);
            Debug.Log("Stunned till " + stunTime + "\nCurrent time: " + Time.realtimeSinceStartup);
        }
        
    }

    private void stealCandy()
    {
        if (stealTime < Time.realtimeSinceStartup) {
            CANDY -= stealAmount;
            Debug.Log("Steal " + stealAmount + " candy\nHas " + CANDY + " candy left");
            if (CANDY <= 0) {
                //GAMEOVER
                Debug.Log("OUT OF CANDY");
            } else {
                stealAmount++;
                stealTime = Time.realtimeSinceStartup + stealCD;
            }

        }
    }

    private bool canSeeTarget()
    {
        RaycastHit raycastInfo;
        Vector3 rayToTarget = player.transform.position - transform.position;

        if (Physics.Raycast(transform.position, rayToTarget, out raycastInfo)) {
            if (raycastInfo.transform.gameObject.tag == "Player" && !move.getHiding()) {
                return true;
            }
        }
        return false;
    }

}
