using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float _startDelay;
    [SerializeField] private GameObject[] _objectPrefabs;
    [SerializeField] private bool _isFieldView;

    private Timer _timer;
    private float _currentDelay;

    public bool IsFieldView => _isFieldView;
    public float CurrentDelay => _currentDelay;
    public GameObject[] ObjectsPrefabs => _objectPrefabs;

    private void Awake()
    {
        _timer = GetComponent<Timer>();
        _currentDelay = _startDelay;
        StartTimer();
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
        Spawn();
    }

    public virtual void Spawn()
    {
        Vector3 position = GetRandomPosition();

        if (_isFieldView)
        {
            while (true)
            {
                if (IsVisible(Camera.main, position))
                {
                    Instantiate(_objectPrefabs[Random.Range(0, _objectPrefabs.Length)], position, Quaternion.identity);
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

    public Vector3 GetRandomPosition()
    {
        float maxX = 20f;
        float minX = -20f;
        float maxZ = 15f;
        float minZ = -15f;
        float radius = 1f;

        Vector3 randomPosition = new Vector3(Random.Range(minX, maxX), 0, (Random.Range(minZ, maxZ)));
        Collider[] colliders = Physics.OverlapSphere(randomPosition, radius);

        foreach (Collider collider in colliders)
        {
            if (collider.TryGetComponent(out Obstacle obstacle))
            {
                GetRandomPosition();
            }
        }

        return randomPosition;
    }

    public bool IsVisible(Camera camera, Vector3 point)
    {
        Vector3 viewportPoint = camera.WorldToViewportPoint(point);
        return viewportPoint.x >= 0 && viewportPoint.x <= 1 && viewportPoint.y >= 0 && viewportPoint.y <= 1 && viewportPoint.z >= 0;
    }

    public void OnDelayDecremented(float delay)
    {
        _currentDelay = delay;
    }

    public void StartTimer()
    {
        _timer.StartWork(_currentDelay);
    }
}