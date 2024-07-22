using TMPro;
using UnityEngine;

public class ScoresView : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private string _scoreText;
    [SerializeField] private ScoreWallet _wallet;

    private void OnEnable() => _wallet.ValueChanged += OnValueChanged;

    private void OnDisable() => _wallet.ValueChanged -= OnValueChanged;

    public void ShowReccord()
    {
        _text.text = _scoreText + _wallet.GetReccord().ToString();
    }

    private void OnValueChanged(int value)
    {
        _text.text = _scoreText + value.ToString();
    }
}