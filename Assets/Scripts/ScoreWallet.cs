using System;
using UnityEngine;

public class ScoreWallet : MonoBehaviour
{
    private int _value;
    private int _currentReccord;
    private bool _isNewReccord = false;

    public Action<int> ValueChanged;

    public bool IsNewReccord => _isNewReccord;

    private void Start()
    {
        _currentReccord = PlayerPrefs.GetInt("Reccord", 0);
        _value = 0;
        ValueChanged?.Invoke(_value);
    }

    public void IncreaseScore(int value)
    {
        if (value < 0)
            return;

        _value += value;

        if (_value > _currentReccord)
        {
            PlayerPrefs.SetInt("Reccord", _value);
            _isNewReccord = true;
            PlayerPrefs.Save();
        }

        ValueChanged?.Invoke(_value);
    }

    public int GetReccord()
    {
        if (_isNewReccord)
            return _value;
        return _currentReccord;
    }
}
