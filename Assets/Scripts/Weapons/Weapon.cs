using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private int _damage;
    [SerializeField] private float _speedShoot;
    [SerializeField] private ParticleSystem _particleSystem;
    [SerializeField] private float _distance;

    private Timer _timer;

    public float SpeedShoot => _speedShoot;
    public Timer Timer => _timer;
    public float Distance => _distance;
    public int Damage => _damage;
    public Transform Shootpoint => _shootPoint;

    private void Awake()
    {
        _timer = GetComponent<Timer>();
    }

    public virtual void Shoot()
    {
        if (CanShoot())
        {
            if (Physics.Raycast(_shootPoint.position, _shootPoint.forward, out RaycastHit hitInfo))
            {
                _particleSystem.Play();

                if (hitInfo.collider.TryGetComponent(out Health health))
                {
                    ApplyDamage(health);
                    print("shoot");
                }
            }

            _timer.StartWork(_speedShoot);
        }
    }

    public bool CanShoot()
    {
        if (_timer.IsWork == false)
            return true;

        return false;
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
