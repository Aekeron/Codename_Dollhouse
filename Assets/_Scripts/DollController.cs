using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DollController : MonoBehaviour
{
    [SerializeField]
    State curState;

    [SerializeField]
    Transform[] roomsToPatrol;

    [SerializeField]
    float roomIdleTime;

    //Internal
    int curPoint = 0;

    bool canDoubleSearch = true;

    float timer = 0;

    NavMeshAgent dollAgent;

    enum State
    {
        Patrol,
        Investigate,
        Engage
    }

    // Start is called before the first frame update
    void Awake()
    {
        dollAgent = GetComponent<NavMeshAgent>();
        dollAgent.stoppingDistance = .2f;
    }

    // Update is called once per frame
    void Update()
    {
        switch(curState)
        {
            case State.Patrol:

                Patrol_Callback();

                break;

            case State.Investigate:



                break;

        }
    }

    void Patrol_Callback()
    {
        if(dollAgent.hasPath)
        {

        }
        else
        {
            timer -= Time.deltaTime;

            if (timer <= 0)
            {
                dollAgent.SetDestination(roomsToPatrol[GetNewPatrolPoint()].position);
                timer = roomIdleTime;
            }
        }
    }


    int GetNewPatrolPoint()
    {
        int rand = Random.Range(0, 3);

        if(curPoint == rand)
        {
            if (canDoubleSearch)
            {
                //Deep Search
                Debug.Log("Deep Search");
            } 
            else
            {
                curPoint = GetNewPatrolPoint();
            }
        } 
        else
        {
            curPoint = rand;
        }

        return curPoint;
    }
}
