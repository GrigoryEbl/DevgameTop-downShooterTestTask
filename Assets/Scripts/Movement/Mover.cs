using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private float _speed = 4f;
    [SerializeField] private float _rotationSpeed = 1f;

    private Transform _transform;
    private Rigidbody _rigidbody;

    public float CurrentSpeed { get; private set; }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _transform = transform;
        CurrentSpeed = _speed;
    }

    public void Move(Vector3 direction)
    {
        _rigidbody.velocity = direction.normalized * CurrentSpeed;
    }

    public void Rotate(Quaternion targetRotation)
    {
        targetRotation.x = 0;
        targetRotation.z = 0;
        _rigidbody.rotation = Quaternion.Slerp(_transform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);
    }

    public void Stop()
    {
        if (_rigidbody != null)
        {
            _rigidbody.velocity = Vector3.zero;
        }
    }

    public void ChangeSpeed(float speed)
    {
        CurrentSpeed = speed;
    }
}