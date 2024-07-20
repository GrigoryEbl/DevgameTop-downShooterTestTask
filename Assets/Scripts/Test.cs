using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Test : MonoBehaviour
{
    [SerializeField] private GameObject _objectPrefab;
    private Timer _timer;

    private void Awake()
    {
        _timer = GetComponent<Timer>();
        _timer.StartWork(2);
    }

    private void OnEnable()
    {
        _timer.TimeEmpty += OnTimeEmpty;
    }

    private void OnDisable()
    {
        _timer.TimeEmpty -= OnTimeEmpty;
    }

    private void OnTimeEmpty()
    {
        Instantiate(_objectPrefab, transform.position, Quaternion.identity, transform);
        _timer.StartWork(2);
    }
}
