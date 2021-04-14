using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task_LoSDetection : PawnTask
{
    //Origin Transform -> Object casting LoSDetection
    Transform origin;
    //Target transform -> Object to search for
    Transform focusObj;

    //Line of Sight Range -> How far to search for object
    float losRange;

    //Task Complete Boolean -> If focusObj is within LoS Raycasts cast from Origin
    public override bool TaskComplete()
    {
        //If focusObj is within Line of Sight Range
        if(Vector3.Distance(origin.position, focusObj.position) <= losRange)
        {
            //Task complete
            return true;
        }

        //Task not complete
        return false;
    }

    public Task_LoSDetection(Transform objA, Transform objB, float range)
    {
        //Reference Origin
        origin = objA;
        //Reference Focus
        focusObj = objB;
        //Set LoS Range
        losRange = range;
    }

}
