using UnityEngine;

public class CameraMover : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private int _cameraPositionZ;
    [SerializeField] private int _cameraPositionY;
    [SerializeField] private float _offsetX;
    [SerializeField] private float _offsetZ;

    [Header("Positions")]
    [SerializeField] private float _maxPositionX = 40f;
    [SerializeField] private float _minPositionX = -40;
    [SerializeField] private float _maxPositionZ = -25f;
    [SerializeField] private float _minPositionZ = -60f;
    [SerializeField] private float _maxPositionY = 9f;
    [SerializeField] private float _minPositionY = 3.5f;

    private Vector3 _target;
    private Transform _transform;

    private void Awake()
    {
        _transform = transform;
    }

    private void Update()
    {
        _target = _player.position;
        _target.z += _cameraPositionZ;
        _target.y += _cameraPositionY;
        _transform.position = _target;
        ClampPosition();
    }

    private void ClampPosition()
    {
        Vector3 clampedPosition = _transform.position;

        clampedPosition.x = Mathf.Clamp(clampedPosition.x, _minPositionX, _maxPositionX);
        clampedPosition.y = Mathf.Clamp(clampedPosition.y, _minPositionY, _maxPositionY);
        clampedPosition.z = Mathf.Clamp(clampedPosition.z, _minPositionZ, _maxPositionZ);

        _transform.position = clampedPosition;
    }
}
