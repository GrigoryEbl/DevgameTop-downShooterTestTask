using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Weapon _startWeapon;
    [SerializeField] private bool _isInvulnerable;
    [SerializeField] private Transform _weaponCell;

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

        if (other.TryGetComponent(out Bonus bonus))
        {
            bonus.ApplyEffect(this);
            return;
        }
    }

    public void SetWeapon(Weapon weapon)
    {
        weapon = Instantiate(weapon, _weaponCell.transform.position, Quaternion.identity, _weaponCell.transform);
        Destroy(_weapon.gameObject);
        _weapon = weapon;
        _startWeapon = _weapon;
        _weapon.transform.rotation = _weaponCell.rotation;
    }

    public IEnumerator SpeedBoost(float duration)
    {
        float addedSpeed = 1.5f;
        Mover mover = GetComponent<Mover>();

        mover.ChangeSpeed(mover.CurrentSpeed + addedSpeed);

        yield return new WaitForSeconds(duration);

        mover.ChangeSpeed(mover.CurrentSpeed - addedSpeed);
    }

    public IEnumerator Invincibility(float duration)
    {
        _isInvulnerable = true;

        yield return new WaitForSeconds(duration);

        _isInvulnerable = false;
    }

    private void Shoot()
    {
        if (_weapon != null)
            _weapon.Shoot();
    }
}