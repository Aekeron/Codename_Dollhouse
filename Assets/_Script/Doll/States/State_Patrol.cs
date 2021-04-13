using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class State_Patrol : PawnState
{
    NavMeshAgent pawnAgent;

    public override bool ExecuteCycle()
    {
        for(int i = 0; i < curTasks.Count; i++)
        {
            if(curTasks[i].TaskComplete())
            {
                return true;
            }
        }

        return false;
    }

    public State_Patrol(Transform[] rooms, NavMeshAgent agent)
    {
        curTasks.Add(new Task_MoveToLocation(agent, rooms[0].position));
    }

}
