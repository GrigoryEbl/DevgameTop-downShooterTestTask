using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Weapon _startWeapon;
    [SerializeField] private bool _isInvulnerable;

    private Weapon _weapon;

    private void Awake()
    {
        _weapon = _startWeapon;
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Shoot();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Enemy enemy))
        {
            if (_isInvulnerable)
                return;
            else
                Destroy(gameObject);
        }
    }

    private void Shoot()
    {
        _weapon.Shoot();
    }
}