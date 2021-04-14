using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PawnInterface : MonoBehaviour
{
    PawnState currentState;

    bool pawnIsFocused = false;

    [SerializeField]
    RoomInterface[] rooms;

    [SerializeField]
    GameObject player;

    State_Results results;

    private void Start()
    {
        GameObject[] nodes = GameObject.FindGameObjectsWithTag("Room_Node");
        rooms = new RoomInterface[nodes.Length];

        for(int i = 0; i < nodes.Length; i++)
        {
            rooms[i] = nodes[i].GetComponent<RoomInterface>();
        }

        ExecuteNewState(State_Tag.PatrolState);
    }

    public void Update()
    {
        if(currentState.ExecuteCycle(ref results))
        {
            ExecuteNewState(results.nextState);
        }
    }

    public void AlertNpc_Callback(RoomInterface room)
    {

    }

    void ExecuteNewState(State_Tag state)
    {
        switch(state)
        {
            case State_Tag.PatrolState:
                currentState = new State_Patrol(rooms, GetComponent<NavMeshAgent>(), transform, player.transform);
                break;

            case State_Tag.AggroState:

                currentState = new State_Aggro(GetComponent<NavMeshAgent>(), player.transform);

                break;

            case State_Tag.Idle:

                currentState = new State_Idle();

                break;
        }
    }


}
