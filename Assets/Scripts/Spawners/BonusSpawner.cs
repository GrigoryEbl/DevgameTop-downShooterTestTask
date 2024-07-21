using UnityEngine;

public class BonusSpawner : Spawner
{
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
        Vector3 position = GetRandomPosition(ScanObstacleRadius);

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
                    position = GetRandomPosition(ScanObstacleRadius);
                }
            }
        }
    }

    public override GameObject GetObject()
    {
        GameObject randomObject = ObjectsPrefabs[Random.Range(0, ObjectsPrefabs.Length)];
        return randomObject;
    }
}