using UnityEngine;

public class StartGame : MonoBehaviour
{
    [SerializeField] private GameObject _startPanel;

    private void Start()
    {
        _startPanel.GetComponent<ScoresView>().ShowReccord();
    }
}