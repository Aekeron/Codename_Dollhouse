using UnityEngine;
using UnityEngine.AI;
public class Task_MoveToLocation : PawnTask
{
    //NavMeshAgent Handle -> Used to check/reset navmesh pathing
    public NavMeshAgent pawnAgent;


    //Task Complete Boolean
    public override bool TaskComplete()
    {
        //If pawn has reached its destination
        if(pawnAgent.remainingDistance <= pawnAgent.stoppingDistance)
        {
            //Task is complete
            return true;
        }

        //Task is not complete
        return false;
    }

    public Task_MoveToLocation(NavMeshAgent agent, Vector3 location)
    {
        //Reference NavMeshAgent
        pawnAgent = agent;

        //Adjust stopping distance for pathfinding
        pawnAgent.stoppingDistance = .2f;

        //If target has a path that is not to the new location
        if(!pawnAgent.hasPath || pawnAgent.pathEndPosition != location)
        {
            //Set new destination
            pawnAgent.SetDestination(location);
        }   
    }
}
