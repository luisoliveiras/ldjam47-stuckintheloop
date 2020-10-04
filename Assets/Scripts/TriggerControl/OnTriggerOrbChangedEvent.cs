using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Scriptable Objects/OnTriggerOrbChanged", fileName = "new OnTriggerOrbChanged")]
public class OnTriggerOrbChangedEvent : ScriptableObject 
{
    [SerializeField] UnityEvent eventTrigger;


    public void AddListener(UnityAction action)
    {
        eventTrigger.AddListener(action);
    }

    public void RemoveListener(UnityAction action)
    {
        eventTrigger.RemoveListener(action);
    }

    public void Trigger()
    {
        eventTrigger.Invoke();
    }
}