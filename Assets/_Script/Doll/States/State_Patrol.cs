using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class State_Patrol : PawnState
{
    //NavMeshAgent Handle
    NavMeshAgent pawnAgent;

    //Pawn Transform Handle
    Transform pawnTransform;

    //Exit Task Handle
    Task_LoSDetection trackPlayer;
    //Primary Task Handle
    Task_MoveToLocation patrolTask;

    //Rooms Handle
    RoomInterface[] roomsToPatrol;
    //Index of room last visited
    int roomIndex = 0;
    //Index of patrol point last visited
    int patrolIndex = 0;

    //Flag to go to next room
    bool goToNextRoom = false;
    //Allows NPC to visit same room twice
    bool canDoubleSearch = false;


    public override bool ExecuteCycle(ref State_Results results)
    {
        //If exit task is complete
        if(trackPlayer.TaskComplete())
        {
            //Set next state within results
            results.nextState = State_Tag.AggroState;

            //State Complete
            return true;
        }

        //If Primary task is complete
        if(patrolTask.TaskComplete())
        {
            //If we are finished with the last target room
            if(goToNextRoom)
            {
                //Single Run Flag
                goToNextRoom = false;

                //Find next room
                roomIndex = GetNextRoom();

                //Reset patrol index
                patrolIndex = 0;

                //Set Primary Task to new task -> Move to next room
                patrolTask = new Task_MoveToLocation(pawnAgent, roomsToPatrol[roomIndex].transform.position);
            } 
            else
            {
                //If pawn has more points to explore within room
                if(patrolIndex < roomsToPatrol[roomIndex].patrolRoute.Length)
                {
                    //Set Primary Task -> Move to next point within room
                    patrolTask = new Task_MoveToLocation(pawnAgent, roomsToPatrol[roomIndex].patrolRoute[patrolIndex]);

                    patrolIndex++;
                }
                else
                {
                    //Set flag to move to new room
                    goToNextRoom = true;
                }
            }
        }

        return false;
    }

    int GetNextRoom()
    {
        //Store potential room in a temp variable
        int temp = Random.Range(0, roomsToPatrol.Length - 1);

        //If temp matches last cycles result and double search is disabled
        if(temp == roomIndex && !canDoubleSearch)
        {
            //Generate new option
            temp = GetNextRoom();
        }

        //return final option
        return temp;
    }

    public State_Patrol(RoomInterface[] rooms, NavMeshAgent agent, Transform pawn, Transform player)
    {
        //Store list of rooms to patrol 
        roomsToPatrol = rooms;
        //Reference NavMeshAgent
        pawnAgent = agent;
        //Reference Pawn Transform
        pawnTransform = pawn;

        //Create Exit Task -> Track player via line of sight
        trackPlayer = new Task_LoSDetection(pawn, player, 4);

        //Find the first room to patrol
        roomIndex = GetNextRoom();
        //Reset patrol index
        patrolIndex = 0;

        //Create first Primary Task -> Move to first room in stored array
        patrolTask = new Task_MoveToLocation(pawnAgent, roomsToPatrol[roomIndex].patrolRoute[patrolIndex]);
    }

}
