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
        
    }

    // Update is called once per frame
    void Update()
    {
        switch(attState)
        {
            case AttributeState.Patrol:


                break;
        }
    }

    public void SwitchToState(DollState target)
    {

    }
}
