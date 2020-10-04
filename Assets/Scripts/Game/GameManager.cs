using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Scenes")]
    [SerializeField] SceneChanger _sceneChanger; 

    [Header("End Game Condition")]
    [SerializeField] List<OrbTriggerPair> _triggers;
    [Space]
    [SerializeField] OnTriggerOrbChangedEvent _onTriggerOrbChanged;

    [Header("Player")]
    [SerializeField] PlayerData _player;

    private void Start()
    {
        _onTriggerOrbChanged.AddListener(CheckEndGameCondition);
    }

    private void OnDestroy()
    {
        _onTriggerOrbChanged.RemoveListener(CheckEndGameCondition);
    }

    void CheckEndGameCondition()
    {
        foreach (var trigger in _triggers)
        {
            if (!trigger.IsComplete)
                return;
        }
        _player.ResetOrbs();
        _sceneChanger.MoveToEndGame();
    }

    public void Rewind()
    {
        _sceneChanger.MoveToGame();
    }
}

[Serializable]
public struct OrbTriggerPair
{
    [SerializeField] TriggerComponent _trigger;
    [SerializeField] OrbData _orb;

    public bool IsComplete { get => _trigger.ContainOrb(_orb); }
}