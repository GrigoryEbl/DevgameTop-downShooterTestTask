using UnityEngine;

public class WeaponSpawner : Spawner
{
    [SerializeField] private Transform _playerWeaponCell;
    [SerializeField] private WeaponBonus[] _weaponBonuses;

    private void Awake()
    {
        Init();
    }

    private void OnEnable()
    {
        Timer.TimeEmpty += OnTimeEmpty;
    }

    private void OnDisable()
    {
        Timer.TimeEmpty -= OnTimeEmpty;
    }

    public override void Spawn()
    {
        Vector3 position = GetRandomPosition();

        if (IsFieldView)
        {
            while (true)
            {
                if (IsVisible(Camera.main, position))
                {
                    Instantiate(GetObject(), position, Quaternion.identity, transform);
                    StartTimer();
                    return;
                }
                else
                {
                    position = GetRandomPosition();
                }
            }
        }
    }

    public override GameObject GetObject()
    {
        WeaponBonus weaponBonus = GetRandomOdject();

        if (weaponBonus.TryGetComponent(out Weapon weapon)
            && weapon.Name == GetPlayerWeaponName())
        {
            weaponBonus = GetRandomOdject();
        }

        return weaponBonus.gameObject;
    }

    private WeaponBonus GetRandomOdject()
    {
        WeaponBonus weaponBonus = _weaponBonuses[Random.Range(0, _weaponBonuses.Length)];
        return weaponBonus;
    }

    private string GetPlayerWeaponName()
    {
        return _playerWeaponCell.GetComponentInChildren<Weapon>().Name;
    }
}
