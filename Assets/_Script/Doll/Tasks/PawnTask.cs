using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PawnTask
{
    public bool asyncQue;
    public bool deleteOnFinish;

    public abstract bool TaskComplete();
}
