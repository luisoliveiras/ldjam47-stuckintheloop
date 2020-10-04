using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DoubleTriggerDoorComponent : DoorComponent
{
    [SerializeField] List<DoorDoubleTriggerCondition> _openConditions;

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
