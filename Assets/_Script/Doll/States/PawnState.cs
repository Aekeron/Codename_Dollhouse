//*************************************************************************************
// Doll State Abstract Base Class. Holds parent functionality for any possible NPC state 
//*************************************************************************************

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PawnState
{
    public List<PawnTask> curTasks = new List<PawnTask>();

    public abstract bool ExecuteCycle(ref State_Results results);
    public virtual void ExternalTrigger(int code)
    {

    }
    public virtual void ExternalTrigger<t>(int code, t attribute)
    {

    }
    public virtual void ExternalTrigger<t>(int code, t[] attributes)
    {

    }

}

public struct State_Results
{
    public State_Tag nextState;
}

public enum State_Tag
{
    Idle,
    PatrolState,
    AlertState,
    AggroState
}


