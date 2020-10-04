using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    [Header("Timer")]
    [SerializeField] Text _timerText;
    [SerializeField] Color _defaultTextColor;
    [SerializeField] int _highlightThreshold;
    [SerializeField] Color _highlightTextColor;

    public void UpdateTimerValue(int value)
    {
        if (value < _highlightThreshold)
            _timerText.color = _highlightTextColor;
        else
            _timerText.color = _defaultTextColor;

        _timerText.text = value.ToString();
    }
}
