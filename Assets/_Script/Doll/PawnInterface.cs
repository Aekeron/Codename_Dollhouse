using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PawnInterface : MonoBehaviour
{
    PawnState currentState;

    bool pawnIsFocused = false;

    [SerializeField]
    Transform[] rooms;

    private void Start()
    {
        currentState = new State_Patrol(rooms, GetComponent<NavMeshAgent>());
    }

    public void Update()
    {
        if(currentState.ExecuteCycle())
        {
            Debug.Log("Cycle Is Complete");
        }
    }

}
