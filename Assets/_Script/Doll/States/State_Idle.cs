using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This is just a placeholder idle class for testing at this stage. No documentation needed.

public class State_Idle : PawnState
{
    float timer = 5;

    public override bool ExecuteCycle(ref State_Results results)
    {
        timer -= Time.deltaTime;

        if(timer <= 0)
        {
            results.nextState = State_Tag.PatrolState;
            return true;
        }

        return false;
    }
}
