using TMPro;
using UnityEngine;

public class ScoresView : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private ScoreWallet _wallet;

    private string _scoreText = "Scroes: ";

    private void OnEnable() => _wallet.ValueChanged += ShowValue;

    private void OnDisable() => _wallet.ValueChanged -= ShowValue;

    private void ShowValue(int value)
    {
        _text.text = _scoreText + value.ToString();
    }
}
