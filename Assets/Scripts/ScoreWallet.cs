using System;
using UnityEngine;

public class ScoreWallet : MonoBehaviour
{
    private int _value;
    private int _currentReccord;
    private bool _isNewReccord = false;

    public Action<int> ValueChanged;

    private void Start()
    {
        _currentReccord = PlayerPrefs.GetInt("Reccord", 0);

        ValueChanged?.Invoke(_value);
    }

    public void IncreaseScore(int value)
    {
        if (value < 0)
            return;

        _value += value;

        if (_currentReccord < _value)
        {
            PlayerPrefs.SetInt("Reccord", _value);
            _isNewReccord = true;
            PlayerPrefs.Save();
        }

        ValueChanged?.Invoke(_value);
    }


    public int GetReccord()
    {
        if (_currentReccord > _value)
            return _value;
        return _currentReccord;
    }
}
