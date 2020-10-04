using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Scriptable Objects/OnTriggerOrbChanged", fileName = "new OnTriggerOrbChanged")]
public class OnTriggerOrbChangedEvent : ScriptableObject 
{
    public UnityEvent triggerEvent;

    public void Trigger()
    {
        triggerEvent.Invoke();
    }
}