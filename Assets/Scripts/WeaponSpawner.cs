using UnityEngine;

public class WeaponSpawner : Spawner
{
    [SerializeField] private Transform _playerWeaponCell;

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
                    Instantiate(GetObject(), position, Quaternion.identity);
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
        GameObject gameObject = GetRandomOdject();

        if (gameObject.TryGetComponent(out Weapon weapon)
            && weapon.Name == GetPlayerWeaponName())
        {
            gameObject = GetRandomOdject();
        }

        return gameObject;
    }

    private GameObject GetRandomOdject()
    {
        GameObject randomObject = ObjectsPrefabs[Random.Range(0, ObjectsPrefabs.Length)];
        return randomObject;
    }

    private string GetPlayerWeaponName()
    {
       return _playerWeaponCell.GetComponentInChildren<Weapon>().Name;
    }
}
