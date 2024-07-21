using System;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private float _speed = 4f;
    [SerializeField] private float _rotationSpeed = 1f;

    private Transform _transform;
    private Rigidbody _rigidbody;

    public Action<bool> Moved;

    public float CurrentSpeed { get; private set; }
    public bool IsMoving { get; private set; }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _transform = transform;
        CurrentSpeed = _speed;
    }

    public void Move(Vector3 direction)
    {
        _rigidbody.velocity = direction.normalized * CurrentSpeed;

        IsMoving = true;
        Moved?.Invoke(IsMoving);
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
            IsMoving = false;
            Moved?.Invoke(IsMoving);
        }
    }

    public void ChangeSpeed(float speed)
    {
        CurrentSpeed = speed;
    }
}