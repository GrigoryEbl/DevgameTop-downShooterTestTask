using UnityEngine;

public class LossHandler : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private GameObject _lossPanel;

    private void OnEnable()
    {
        _player.Died += OnPlayerDied;
    }

    private void OnDisable()
    {
        _player.Died -= OnPlayerDied;
    }

    private void OnPlayerDied()
    {
        _lossPanel.SetActive(true);
        _lossPanel.GetComponent<ScoresView>().ShowReccord();
        Time.timeScale = 0f;
    }
}