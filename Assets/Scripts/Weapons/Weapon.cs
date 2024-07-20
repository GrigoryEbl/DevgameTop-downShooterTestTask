using System.Collections;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private int _damage;
    [SerializeField] private float _speedShoot;
    

    private Timer _timer;

    public float SpeedShoot => _speedShoot;
    public Timer Timer => _timer;
    public int Damage => _damage;
    public Transform ShootPoint => _shootPoint;

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
                Debug.DrawRay(ShootPoint.position, _shootPoint.forward * hitInfo.distance, Color.red, 1f);

                if (hitInfo.collider.TryGetComponent(out Health health))
                {
                    ApplyDamage(health);
                    print("shoot");
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
    }

    //private void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.yellow;

    //    if (Physics.Raycast(_shootPoint.position, _shootPoint.forward, out RaycastHit hitInfo))
    //    {
    //        Gizmos.DrawLine(_shootPoint.position, hitInfo.point);
    //    }
    //}
}
