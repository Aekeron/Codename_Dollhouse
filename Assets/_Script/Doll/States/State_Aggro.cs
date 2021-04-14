using UnityEngine;
using UnityEngine.AI;

public class State_Aggro : PawnState
{
    //Exit Task  Handle
    Task_ChaseTarget exitTask;

    public override bool ExecuteCycle(ref State_Results results)
    {
        //If exit task is complete -> NPC has caught player
        if (exitTask.TaskComplete())
        {
            //Set next state to idle, will update this late
            results.nextState = State_Tag.Idle;
            //Execute next cycle
            return true;
        }

        //Continue this cycles
        return false;
    }

    public State_Aggro(NavMeshAgent agent, Transform target)
    {
        //Create new exit task -> Chase playery until it catches them
        exitTask = new Task_ChaseTarget(agent, target);
    }
}
