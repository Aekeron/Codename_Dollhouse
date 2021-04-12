using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DollController : MonoBehaviour
{
    [SerializeField]
    float moveSpeed;



    DollState dollState;
    AttributeState attState;

    public enum AttributeState
    {
        Patrol
    }

    // Start is called before the first frame update
    void Start()
    {
        GameObject[] rooms = GameObject.FindGameObjectsWithTag("RoomNode");
        Transform[] roomTrans = new Transform[rooms.Length];

        for(int i = 0; i < rooms.Length; i++)
        {
            roomTrans[i] = rooms[i].transform;
        }
        GetComponent<NavMeshAgent>().speed = moveSpeed;
        dollState = new State_Patrol(roomTrans, GetComponent<NavMeshAgent>());
    }

    // Update is called once per frame
    void Update()
    {
        switch(attState)
        {
            case AttributeState.Patrol:

                dollState.ExecuteCycle();

                break;
        }
    }

    public void SwitchToState(DollState target)
    {

    }
}
