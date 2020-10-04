using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    [SerializeField] int _timeLimit;
    float _timerCount;
    int _secondsElapsed;

    [Header("Events")]
    public IntUnityEvent OnCountdownValueChange;
    public UnityEvent OnCountDownFinished;

    // Start is called before the first frame update
    void Start()
    {
        _timerCount = 0;
        _secondsElapsed = 0;
        OnCountdownValueChange.Invoke(_timeLimit);
    }

    // Update is called once per frame
    void Update()
    {
        _timerCount += Time.deltaTime;
        if (_timerCount > _secondsElapsed + 1)
        {
            _secondsElapsed++;
            OnCountdownValueChange.Invoke(_timeLimit - _secondsElapsed);
        }
        if (_timeLimit - _secondsElapsed <= 0)
        {
            OnCountDownFinished.Invoke();
            SceneManager.LoadScene("Main");
        }
    }
}
[Serializable]
public class IntUnityEvent: UnityEvent<int> { }