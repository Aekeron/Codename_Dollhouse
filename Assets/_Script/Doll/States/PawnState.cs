//*************************************************************************************
// Doll State Abstract Base Class. Holds parent functionality for any possible NPC state 
//*************************************************************************************

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PawnState
{
    public List<PawnTask> curTasks = new List<PawnTask>();

    public abstract bool ExecuteCycle();
}