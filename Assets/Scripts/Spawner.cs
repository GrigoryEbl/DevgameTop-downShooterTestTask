using UnityEngine;

public abstract class Spawner : MonoBehaviour
{
    [SerializeField] protected GameObject ObjectPrefab;
    [SerializeField] private float _startDelay;
    [SerializeField] private bool _isFieldView;
    
    private Timer _timer;
    private float _currentDelay;

    public float StartDelay => _startDelay;
    public bool IsFieldView => _isFieldView;

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

    private void Update()
    {
        if (_timer == null)
        {
            Debug.LogError("Timer component not found on the same GameObject.");
        }
        else
            print("Timer has");
    }

    public abstract void Spawn();

    public Vector3 GetRandomPosition()
    {
        float maxX = 20f;
        float minX = -20f;
        float maxZ = 15f;
        float minZ = -15f;

        return new Vector3(Random.Range(minX, maxX), 0, (Random.Range(minZ, maxZ)));
    }

    public bool IsVisible(Camera camera, Vector3 point)
    {
        Vector3 viewportPoint = camera.WorldToViewportPoint(point);
        return viewportPoint.x >= 0 && viewportPoint.x <= 1 && viewportPoint.y >= 0 && viewportPoint.y <= 1 && viewportPoint.z >= 0;
    }

    public void ChangeDelay(float delay)
    {
        _currentDelay = delay;
    }

    public void StartTimer()
    {
        _timer.StartWork(_currentDelay);
    }

    private void OnTimeEmpty()
    {
        Spawn();
    }
}