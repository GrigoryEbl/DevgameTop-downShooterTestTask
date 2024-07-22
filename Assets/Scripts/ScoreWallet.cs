using System;
using UnityEngine;

public class ScoreWallet : MonoBehaviour
{
    private int _value;

    public Action<int> ValueChanged;

    private void Start()
    {
        ValueChanged?.Invoke(_value);
    }

    public void IncreaseScore(int value)
    {
        if (value < 0)
            return;
        
        _value += value;

        ValueChanged?.Invoke(_value);
    }
}
