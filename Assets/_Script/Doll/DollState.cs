using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DollState
{
    public virtual void ExecuteCycle()
    {
    }

    public virtual void ExecuteCycle<t>(t attribute)
    {
    }

    public virtual void ExecuteCycle<t>(t[] attributes)
    {

    }

}

