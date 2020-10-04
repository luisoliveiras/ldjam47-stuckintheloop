using System;
using UnityEngine;

[Serializable]
public class DoorSingleTriggerCondition
{
    [SerializeField] TriggerComponent _trigger;
    [SerializeField] OrbData _expectedOrb;
    [SerializeField] bool _expectedValue;

    public bool IsValid()
    {
        bool hasOrb = _trigger.ContainOrb(_expectedOrb);
        return hasOrb == _expectedValue;
    }
}

[Serializable]
public class DoorDoubleTriggerCondition
{
    [Header("Trigger A")]
    [SerializeField] TriggerComponent _triggerA;
    [SerializeField] OrbData _expectedOrbA;
    [SerializeField] bool _expectedValueA;

    [Header("Trigger B")]
    [SerializeField] TriggerComponent _triggerB;
    [SerializeField] OrbData _expectedOrbB;
    [SerializeField] bool _expectedValueB;

    public bool IsValid()
    {
        bool triggerValueA = _triggerA.ContainOrb(_expectedOrbA) == _expectedValueA; 
        bool triggerValueB = _triggerB.ContainOrb(_expectedOrbB) == _expectedValueB; 

        return triggerValueA && triggerValueB;
    }
}