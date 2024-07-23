using TMPro;
using UnityEngine;

public class ScoresView : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private ScoreWallet _wallet;

    private string _scoreText = "Score: ";
    private string _newReccordText = "New reccord: ";

    private void OnEnable() => _wallet.ValueChanged += OnValueChanged;

    private void OnDisable() => _wallet.ValueChanged -= OnValueChanged;

    public void ShowReccord()
    {
        if (_wallet.IsNewReccord)
            ShowScores(_newReccordText, _wallet.GetReccord());
        else
            ShowScores(_scoreText, _wallet.GetReccord());
    }

    private void OnValueChanged(int value)
    {
        ShowScores(_scoreText, value);
    }

    private void ShowScores(string text, int value)
    {
        _text.text = text + value.ToString();
    }
}