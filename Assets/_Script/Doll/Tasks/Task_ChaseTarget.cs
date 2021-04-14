using UnityEngine;
using UnityEngine.AI;

public class Task_ChaseTarget : PawnTask
{
    NavMeshAgent pawnAgent;
    Transform targetObj;

    Vector3 lastPos;

    public override bool TaskComplete()
    {
        //If target has moved
        if(targetObj.position != lastPos)
        {
            //Adjust with new destination
            pawnAgent.SetDestination(targetObj.position);
        }

        //If pawn has arrived at destination
        if (pawnAgent.remainingDistance <= pawnAgent.stoppingDistance)
        {
            //Task is complete
            return true;
        }

        //Task is not complete
        return false;
    }

    public Task_ChaseTarget(NavMeshAgent agent, Transform target)
    {
        //Reference NavMeshAgent
        pawnAgent = agent;
        //Reference Target Transform
        targetObj = target;

        //Adjust stopping speed for pathfinding
        pawnAgent.stoppingDistance = 1.5f;

        //Set last position
        lastPos = target.position;
        //Set first destination
        pawnAgent.SetDestination(targetObj.position);
    }
}
