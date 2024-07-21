using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Weapon _startWeapon;
    [SerializeField] private bool _isInvulnerable;
    [SerializeField] private Transform _weaponCell;

    private Transform _transform;
    private Weapon _weapon;
    private Weapon _previousWeapon;

    private void Awake()
    {
        _transform = transform;
        _weapon = _startWeapon;
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Shoot();
        }
    }
    private int _collisionCount = 0;
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Enemy enemy))
        {
            if (_isInvulnerable)
                return;
            else
                Destroy(gameObject);
        }

        if (other.TryGetComponent(out Weapon weapon))
        {
            _collisionCount++;
            SetWeapon(weapon);
            print("Collision weapon: " + _collisionCount);
            return;
        }
    }

    public void SetWeapon(Weapon weapon)
    {
        weapon.GetComponent<BoxCollider>().enabled = false;
        Destroy(_weapon.gameObject);
        _weapon = null;
        _weapon = weapon;
        _weapon.transform.SetParent(_weaponCell);
        _weapon.transform.position = _weaponCell.position;
        _weapon.transform.rotation = _weaponCell.rotation;
        print("Set new weapon: " + _weapon.name);
    }

    private void Shoot()
    {
        if (_weapon != null)
            _weapon.Shoot();
    }
}