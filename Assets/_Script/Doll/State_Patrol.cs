using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[System.Serializable]
public class State_Patrol : DollState
{
    [SerializeField]
    Transform[] patrolPoints;

    NavMeshAgent dollAgent;

    public override void ExecuteCycle<t>(t[] attributes)
    {
        
    }

    public State_Patrol(Transform[] points, NavMeshAgent agent)
    {
        patrolPoints = points;
        dollAgent = agent;
    }
}
