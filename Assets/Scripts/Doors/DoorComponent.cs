using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DoorComponent : MonoBehaviour
{
    [SerializeField] protected List<GameObject> _doorParts;
    [SerializeField] protected OnTriggerOrbChangedEvent onTriggerOrbChangedEvent;

    public void Start()
    {
        onTriggerOrbChangedEvent.AddListener(ToggleDoor);
        ToggleDoor();
    }

    public void OnDestroy()
    {
        onTriggerOrbChangedEvent.RemoveListener(ToggleDoor);
    }

    public void ToggleDoor()
    {
        bool open = CanBeOpened();
        foreach (var part in _doorParts)
        {
            part.SetActive(!open);
        }
    }

    public abstract bool CanBeOpened();
}

