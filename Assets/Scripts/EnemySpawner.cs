using UnityEngine;

public class EnemySpawner : Spawner
{
    [SerializeField] private DelayDecrementor _delayDecrementor;

    private void Awake()
    {
        Init();
        _delayDecrementor.Init(CurrentDelay);
    }

    private void OnEnable()
    {
        _delayDecrementor.DelayDecremented += OnDelayDecremented;
        Timer.TimeEmpty += OnTimeEmpty;
    }

    private void OnDisable()
    {
        _delayDecrementor.DelayDecremented -= OnDelayDecremented;
        Timer.TimeEmpty -= OnTimeEmpty;
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
        int chanceOne = 60;
        int chanceTwo = 90;
        int chanceThree = 100;

        int percent = CalculateChance();

        if (percent <= chanceOne)
        {
            return ObjectsPrefabs[0];
        }
        else if (percent <= chanceTwo)
        {
            return ObjectsPrefabs[1];
        }
        else if (percent <= chanceThree)
        {
            return ObjectsPrefabs[2];
        }

        return null;
    }

    private int CalculateChance()
    {
        int maxPercent = 100;

        int percent = Random.Range(0, maxPercent);
        return percent;
    }
}
