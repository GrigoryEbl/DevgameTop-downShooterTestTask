using UnityEngine;

public class Grenade : MonoBehaviour
{
    private Transform _transform;
    private Vector3 _targetPosition;
    private float _speed = 20;
    private float _explosionDistance = 0.1f;
    private float _explosionRadius = 2f;
    private int _damage = 10;

    public void Init(Vector3 targetPosition)
    {
        _transform = transform;
        _targetPosition = targetPosition;
    }

    private void Update()
    {
        _transform.position = Vector3.MoveTowards(_transform.position, _targetPosition, _speed * Time.deltaTime);

        if (Vector3.Distance(_transform.position, _targetPosition) <= _explosionDistance)
            Explode();
    }

    private void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(_transform.position, _explosionRadius);

        foreach (Collider collider in colliders)
        {
            if (collider.TryGetComponent(out Health health))
                health.TakeDamage(_damage);
        }

        Destroy(gameObject);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _explosionRadius);
    }
}
