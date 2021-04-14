using UnityEngine;
using UnityEngine.AI;

public class State_Alerted : PawnState
{
    NavMeshAgent pawnAgent;
    RoomInterface roomToSearch;

    Task_MoveToLocation alertTask;
    Task_LoSDetection exitTask;

    bool arrivedToSource = false;n

    public override bool ExecuteCycle(ref State_Results results)
    {
        return true;
    }

    public State_Alerted(NavMeshAgent agent, RoomInterface room)
    {
        roomToSearch = room;

        alertTask = new Task_MoveToLocation(pawnAgent, roomToSearch.transform.position);


    }
}
