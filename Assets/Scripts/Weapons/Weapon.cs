using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private int _damage;
    [SerializeField] private float _speedShoot;

    private Timer _timer;

    private void Awake()
    {
        _timer = GetComponent<Timer>();
    }

    public void Shoot()
    {
        if (_timer.IsWork == false)
        {
            if (Physics.Raycast(_shootPoint.position, _shootPoint.forward, out RaycastHit hitInfo))
            {
                if (hitInfo.collider.TryGetComponent(out Health health))
                {
                    health.TakeDamage(_damage);
                }
            }

            _timer.StartWork(_speedShoot);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;

        if (Physics.Raycast(_shootPoint.position, _shootPoint.forward, out RaycastHit hitInfo))
        {
            Gizmos.DrawLine(_shootPoint.position, hitInfo.point);
        }
    }
}
