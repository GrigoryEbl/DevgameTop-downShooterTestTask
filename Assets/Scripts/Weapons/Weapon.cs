using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private int _damage;
    [SerializeField] private float _speedShoot;
    [SerializeField] private ParticleSystem _particleSystem;
    [SerializeField] private float _distance;

    private Timer _timer;

    public float Distance => _distance;
    public int Damage => _damage;
    public Transform Shootpoint => _shootPoint;

    private void Awake()
    {
        _timer = GetComponent<Timer>();
    }

    public virtual void Shoot()
    {
        if (_timer.IsWork == false)
        {
            if (Physics.Raycast(_shootPoint.position, _shootPoint.forward, out RaycastHit hitInfo))
            {
                _particleSystem.Play();

                if (hitInfo.collider.TryGetComponent(out Health health))
                {
                    ApplyDamage(health);
                    
                }
            }

            _timer.StartWork(_speedShoot);
        }
    }

    public void ApplyDamage(Health health)
    {
        health.TakeDamage(_damage);
    }

    public void VisualizeEffectShoot()
    {
        _particleSystem.Play();
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
