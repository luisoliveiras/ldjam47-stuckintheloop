using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SingleTriggerDoorComponent : DoorComponent
{
    [SerializeField] List<DoorSingleTriggerCondition> _openConditions;


    public override bool CanBeOpened()
    {
        foreach (var condition in _openConditions)
        {
            if (condition.IsValid())
                return true;
        }
        return false;
    }

}
