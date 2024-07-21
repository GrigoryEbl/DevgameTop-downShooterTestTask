using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Timer))]
public class DelayDecrementor : MonoBehaviour
{
    private Timer _timer;
    private float _currentDelay;
    private float _minDecrementedValue = 0.5f;
    private float _decrementedValue = 0.1f;
    private float _delay = 10f;

    public Action<float> DelayDecremented;

    public void Init(float startDelay)
    {
        _timer = GetComponent<Timer>();
        _currentDelay = startDelay;
        _timer.StartWork(_delay);
    }

    private void OnEnable()
    {
        _timer.TimeEmpty += Decrement;
    }

    private void OnDisable()
    {
        _timer.TimeEmpty -= Decrement;
    }

    private void Decrement()
    {
        if (_currentDelay > _minDecrementedValue)
        {
            _currentDelay -= _decrementedValue;
            _timer.StartWork(_delay);
            DelayDecremented?.Invoke(_currentDelay);
        }
    }
}
