using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.PlayerLoop;

public class TriggerComponent : MonoBehaviour
{
    [Header("Orb Info")]
    [SerializeField] SpriteRenderer _orb;
    [SerializeField] OrbData _currentOrb;
    [SerializeField] OrbData _empty;
    [Header("Trigger Info")]
    [SerializeField] TriggerTypeData _triggerType;
    SpriteRenderer _renderer;

    [Space]
    public UnityEvent OnOrbChanged;

    void Start()
    {
        SetupTrigger();
        UpdateOrb();
    }

    public OrbData SwapOrbs(OrbData orb)
    {
        OrbData returnOrb = _currentOrb;
        _currentOrb = orb;
        UpdateOrb();
        OnOrbChanged.Invoke();
        return returnOrb;
    }

    public bool ContainOrb(OrbData orb)
    {
        return _currentOrb == orb;
    }

    void UpdateOrb()
    {
        _orb.gameObject.SetActive(_currentOrb != _empty);
        _orb.color = _currentOrb.color;
    }

    void SetupTrigger()
    {
        _renderer = GetComponent<SpriteRenderer>();
        _renderer.color = _triggerType.triggerColor;
    }

}