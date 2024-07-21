using System.Collections;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private int _damage;
    [SerializeField] private float _speedShoot;
    [SerializeField] private string _name;
    [SerializeField] private ParticleSystem _particleSystem;

    private Timer _timer;

    public string Name => _name;
    public float SpeedShoot => _speedShoot;
    public Timer Timer => _timer;
    public int Damage => _damage;
    public Transform ShootPoint => _shootPoint;

    private void Awake()
    {
        Init();
    }

    public void Init()
    {
        _timer = GetComponent<Timer>();

    }

    public virtual void Shoot()
    {
        if (CanShoot())
        {
            VisualizeEffectShoot();

            if (Physics.Raycast(_shootPoint.position, _shootPoint.forward, out RaycastHit hitInfo))
            {
                Debug.DrawRay(ShootPoint.position, _shootPoint.forward * hitInfo.distance, Color.red, 1f);

                if (hitInfo.collider.TryGetComponent(out Health health))
                {
                    ApplyDamage(health);
                }
            }

            _timer.StartWork(1f / _speedShoot);
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
}
