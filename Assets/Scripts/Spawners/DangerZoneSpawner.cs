
using UnityEngine;

public class DangerZoneSpawner : Spawner
{
    private void Awake()
    {
        Spawn();
    }

    public override GameObject GetObject()
    {
        return ObjectsPrefabs[0];
    }

    public override void Spawn()
    {
        for (int i = 0; i < ObjectsPrefabs.Length; i++)
        {
            Vector3 position = GetRandomPosition(ScanObstacleRadius);
            Instantiate(ObjectsPrefabs[i], position, Quaternion.identity, transform);
        }
    }

    public override Vector3 GetRandomPosition(float radius)
    {
        float maxX = 20f;
        float minX = -20f;
        float maxZ = 15f;
        float minZ = -15f;

        Vector3 randomPosition = new Vector3(Random.Range(minX, maxX), 0, (Random.Range(minZ, maxZ)));
        Collider[] colliders = Physics.OverlapSphere(randomPosition, radius);

        foreach (Collider collider in colliders)
        {
            if (collider.TryGetComponent(out Obstacle obstacle) || collider.TryGetComponent(out DangerZone dangerZone))
            {
                GetRandomPosition(ScanObstacleRadius);
            }
        }

        return randomPosition;
    }

}
