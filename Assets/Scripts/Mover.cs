using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private float _speed = 4f;
    [SerializeField] private float _rotationSpeed = 1f;

    private Transform _transform;

    private void Awake()
    {
        _transform = transform;
    }

    public void Move(Vector3 direction)
    {
        _transform.position = Vector3.MoveTowards(_transform.position, direction + _transform.position, _speed * Time.deltaTime);
    }

    public void Rotate(Quaternion targetRotation)
    {
        _transform.rotation = Quaternion.Slerp(_transform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);
    }
}