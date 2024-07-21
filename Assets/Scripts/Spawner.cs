using UnityEngine;

public abstract class Spawner : MonoBehaviour
{
    [SerializeField] private float _startDelay;
    [SerializeField] private GameObject[] _objectPrefabs;
    [SerializeField] private bool _isFieldView;

    private Timer _timer;
    private float _currentDelay;

    public bool IsFieldView => _isFieldView;
    public float CurrentDelay => _currentDelay;
    public GameObject[] ObjectsPrefabs => _objectPrefabs;
    public Timer Timer => _timer;

    private void Awake()
    {
        Init();
    }
   
    private void OnEnable()
    {
        _timer.TimeEmpty += OnTimeEmpty;
    }

    private void OnDisable()
    {
        _timer.TimeEmpty -= OnTimeEmpty;
    }

    public void Init()
    {
        _timer = GetComponent<Timer>();
        _currentDelay = _startDelay;
        StartTimer();
    }

    public void OnTimeEmpty()
    {
        Spawn();
    }

    public abstract void Spawn();

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
        if(_timer != null)
        _timer.StartWork(_currentDelay);
    }

    public abstract GameObject GetObject();
    
}