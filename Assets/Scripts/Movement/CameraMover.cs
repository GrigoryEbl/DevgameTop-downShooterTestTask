using UnityEngine;

public class CameraMover : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private float _speed = 3f;

    [SerializeField] private float _maxPositionX;
    [SerializeField] private float _minPositionX;
    [SerializeField] private float _maxPositionZ;
    [SerializeField] private float _minPositionZ;

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