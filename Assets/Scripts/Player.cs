using System;
using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Weapon _startWeapon;
    [SerializeField] private bool _isInvulnerable;
    [SerializeField] private Transform _weaponCell;

    private Weapon _weapon;
    private ScoreWallet _scoreWallet;
    private Enemy _enemyInfo;

    public Action Died;

    private void Awake()
    {
        _weapon = _startWeapon;
        _scoreWallet = GetComponent<ScoreWallet>();
    }

    private void OnEnable()
    {
        _weapon.HitedEnemy += AddEnemyInfo;
    }

    private void OnDisable()
    {
        _weapon.HitedEnemy -= AddEnemyInfo;

        if (_enemyInfo != null)
            _enemyInfo.Died -= _scoreWallet.IncreaseScore;
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
                Die();
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

    public void Die()
    {
        Died?.Invoke();
    }

    private void Shoot()
    {
        if (_weapon != null)
            _weapon.Shoot();
    }

    private void AddEnemyInfo(Enemy enemy)
    {
        RemoveEnemyInfo();
        _enemyInfo = enemy;
        _enemyInfo.Died += _scoreWallet.IncreaseScore;
    }

    private void RemoveEnemyInfo()
    {
        if (_enemyInfo != null)
            _enemyInfo.Died -= _scoreWallet.IncreaseScore;
    }
}