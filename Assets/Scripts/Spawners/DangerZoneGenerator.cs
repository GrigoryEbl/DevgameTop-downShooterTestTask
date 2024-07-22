
using UnityEngine;

public class DangerZoneGenerator : MonoBehaviour
{
    [SerializeField] private DangerZone[] _dangerZonesPrefabs;

    private float _scanObstacleRadius = 1f;

    private void Awake()
    {
        Generate();
    }

    public void Generate()
    {
        for (int i = 0; i < _dangerZonesPrefabs.Length; i++)
        {
            Vector3 position = GetRandomPosition();
            Instantiate(_dangerZonesPrefabs[i], position, Quaternion.identity, transform);
        }
    }

    public Vector3 GetRandomPosition()
    {
        float maxX = 20f;
        float minX = -20f;
        float maxZ = 15f;
        float minZ = -15f;

        Vector3 randomPosition = new Vector3(Random.Range(minX, maxX), 0, (Random.Range(minZ, maxZ)));
        Collider[] colliders = new Collider[10];

        Physics.OverlapSphereNonAlloc(randomPosition, _scanObstacleRadius, colliders);

        foreach (Collider collider in colliders)
        {
            if (collider.TryGetComponent(out Obstacle obstacle) || collider.TryGetComponent(out DangerZone dangerZone))
            {
                GetRandomPosition();
            }
        }

        return randomPosition;
    }

}
