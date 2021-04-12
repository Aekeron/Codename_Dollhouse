using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DollState : MonoBehaviour
{

    public abstract void OnStateEntry();

    public abstract void ExecuteCycle();
}

