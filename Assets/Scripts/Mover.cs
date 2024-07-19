using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private float _speed = 4f;
    [SerializeField] private float _rotationSpeed = 1f;

    private Transform _transform;
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _transform = transform;
    }

    public void Move(Vector3 direction)
    {
        _rigidbody.velocity = direction * _speed;
    }

    public void Rotate(Quaternion targetRotation)
    {
        _rigidbody.rotation = Quaternion.Slerp(_transform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);
    }

    public void Stop()
    {
        if (_rigidbody != null)
        {
            _rigidbody.velocity = Vector3.zero;
        }
    }
}