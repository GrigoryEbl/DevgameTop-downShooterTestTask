using UnityEngine;

[RequireComponent (typeof(Rigidbody))]
public class Mover : MonoBehaviour
{
   [SerializeField] private float _speed = 4f;

    private Transform _transform;
    private Rigidbody _rigidbody;

    public float Speed => _speed;
    public float CurrentSpeed { get; private set; }
    public int Level { get; private set; }
    public bool IsMoving { get; private set; }

    private void Awake()
    {
        _transform = transform;
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void Move(Vector3 direction)
    {
        _transform.LookAt(_transform.position + direction);
        _rigidbody.velocity = direction * _speed;

        CurrentSpeed = _rigidbody.velocity.magnitude;
        IsMoving = true;
    }

    public void Stop()
    {
        if (_rigidbody != null)
            _rigidbody.velocity = Vector3.zero;

        IsMoving = false;
    }
}