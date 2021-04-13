using UnityEngine;
using UnityEngine.AI;
public class Task_MoveToLocation : PawnTask
{
    public NavMeshAgent pawnAgent;

    public override bool TaskComplete()
    {
        if(pawnAgent.remainingDistance <= pawnAgent.stoppingDistance)
        {
            return true;
        }

        return false;
    }

    public Task_MoveToLocation(NavMeshAgent agent, Vector3 location)
    {
        asyncQue = true;
        deleteOnFinish = true;

        pawnAgent = agent;

        if(!pawnAgent.hasPath || pawnAgent.pathEndPosition != location)
        {
            pawnAgent.SetDestination(location);
        }   
    }
}
