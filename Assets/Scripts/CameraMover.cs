using UnityEngine;
using UnityEngine.UIElements;

public class CameraMover : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private float _speed = 3f;

    [Header("Positions")]
    [SerializeField] private float _maxPositionX = 40f;
    [SerializeField] private float _minPositionX = -40;
    [SerializeField] private float _maxPositionZ = -25f;
    [SerializeField] private float _minPositionZ = -60f;

    private Vector3 _target;
    private Transform _transform;
    private float _positionY = 10;

    private void Awake()
    {
        _transform = transform;
    }

    private void Update()
    {
        _target = _player.position;
        _target.y += _positionY;
        _transform.position = Vector3.Lerp(_transform.position, _target, Time.deltaTime * _speed);
        ClampPosition();
    }

    private void ClampPosition()
    {
        Vector3 clampedPosition = _transform.position;

        clampedPosition.x = Mathf.Clamp(clampedPosition.x, _minPositionX, _maxPositionX);
        clampedPosition.z = Mathf.Clamp(clampedPosition.z, _minPositionZ, _maxPositionZ);

        _transform.position = clampedPosition;
    }
}
