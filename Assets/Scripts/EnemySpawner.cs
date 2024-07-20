using UnityEngine;

public class EnemySpawner : Spawner
{
    [SerializeField] private DelayDecrementor _delayDecrementor;

    private void Awake()
    {
        _delayDecrementor.Init(StartDelay);
    }

    private void OnEnable()
    {
        _delayDecrementor.DelayDecremented += ChangeDelay;
    }

    private void OnDisable()
    {
        _delayDecrementor.DelayDecremented -= ChangeDelay;
    }

    public override void Spawn()
    {
        Vector3 position = GetRandomPosition();

        if (IsFieldView == false)
        {
            while (true)
            {
                if (IsVisible(Camera.main, position) == false)
                {
                    Instantiate(ObjectPrefab, position, Quaternion.identity, transform);
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
}
