using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float _startDelay;
    [SerializeField] private GameObject[] _objectPrefabs;
    [SerializeField] private DelayDecrementor _delayDecrementor;
    [SerializeField] private bool _isFieldView;
    [SerializeField] private bool _isDecrementDelay;

    private Timer _timer;
    private float _currentDelay;

    private void Awake()
    {
        _timer = GetComponent<Timer>();
        _currentDelay = _startDelay;
        StartTimer();

        if (_isDecrementDelay)
            _delayDecrementor.Init(_currentDelay);
    }

    private void OnEnable()
    {
        _timer.TimeEmpty += OnTimeEmpty;
        _delayDecrementor.DelayDecremented += OnDelayDecremented;
    }

    private void OnDisable()
    {
        _timer.TimeEmpty -= OnTimeEmpty;
        _delayDecrementor.DelayDecremented -= OnDelayDecremented;
    }

    private void OnTimeEmpty()
    {
        Spawn();
    }

    private void Spawn()
    {
        Vector3 position = GetRandomPosition();

        if (_isFieldView == false)
        {
            while (true)
            {
                if (IsVisible(Camera.main, position) == false)
                {
                    Instantiate(GetObject(), position, Quaternion.identity);
                    StartTimer();
                    return;
                }
                else
                {
                    position = GetRandomPosition();
                }
            }
        }
    }

    private Vector3 GetRandomPosition()
    {
        float maxX = 20f;
        float minX = -20f;
        float maxZ = 15f;
        float minZ = -15f;

        return new Vector3(Random.Range(minX, maxX), 0, (Random.Range(minZ, maxZ)));
    }

    private bool IsVisible(Camera camera, Vector3 point)
    {
        Vector3 viewportPoint = camera.WorldToViewportPoint(point);
        return viewportPoint.x >= 0 && viewportPoint.x <= 1 && viewportPoint.y >= 0 && viewportPoint.y <= 1 && viewportPoint.z >= 0;
    }

    private void OnDelayDecremented(float delay)
    {
        _currentDelay = delay;
    }

    private void StartTimer()
    {
        _timer.StartWork(_currentDelay);
    }

    private GameObject GetObject()
    {
        int chance = CalculateChance();

        int chanceOne = 60;
        int chanceTwo = 90;
        int chanceThree = 100;

        if (chance <= chanceOne)
        {
            return _objectPrefabs[0];
        }
        else if (chance <= chanceTwo)
        {
            return _objectPrefabs[1];
        }
        else if (chance <= chanceThree)
        {
            return _objectPrefabs[2];
        }

        return null;
    }

    private int CalculateChance()
    {
        int maxChance = 100;

        int chance = Random.Range(0, maxChance);
        return chance;
    }
}