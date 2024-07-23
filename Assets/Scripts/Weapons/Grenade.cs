using UnityEngine;

public class Grenade : MonoBehaviour
{
    private Transform _transform;
    private Vector3 _targetPosition;
    private float _speed = 20;
    private float _explosionDistance = 0.1f;
    private float _explosionRadius = 2f;
    private int _damage = 10;
    private Transform _parent;

    public void Init(Vector3 targetPosition, Transform parent)
    {
        _transform = transform;
        _targetPosition = targetPosition;
        _parent = parent;
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
            {
                health.TakeDamage(_damage);
                _parent.GetComponent<Weapon>().InvokEvent(health);
            }
        }

        Destroy(gameObject);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _explosionRadius);
    }
}