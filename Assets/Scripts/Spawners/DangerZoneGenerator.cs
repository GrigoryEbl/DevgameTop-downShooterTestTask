using UnityEngine;

public class DangerZoneGenerator : MonoBehaviour
{
    [SerializeField] private DangerZone[] _dangerZonesPrefabs;

    private float _scanObstacleRadius = 4.5f;

    private void Awake()
    {
        Generate();
    }

    private void Generate()
    {
        Vector3 newPosition;
        int maxAttempts = 100;
        int currentAttempts = 0;

        for (int i = 0; i < _dangerZonesPrefabs.Length; i++)
        {
            do
            {
                newPosition = GetRandomPosition();
                currentAttempts++;
            }
            while (IsValidPosition(newPosition) == false && currentAttempts < maxAttempts);
            {
                if (currentAttempts < maxAttempts)
                {
                    Instantiate(_dangerZonesPrefabs[i], newPosition, Quaternion.identity, transform);
                }
            }
        }
    }

    private Vector3 GetRandomPosition()
    {
        float maxX = 20f;
        float minX = -20f;
        float maxZ = 15f;
        float minZ = -15f;

        return new Vector3(Random.Range(minX, maxX), transform.position.y, (Random.Range(minZ, maxZ)));
    }

    private bool IsValidPosition(Vector3 position)
    {
        Collider[] hitColliders = Physics.OverlapSphere(position, _scanObstacleRadius);

        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.TryGetComponent(out Obstacle obstacle) || hitCollider.TryGetComponent(out DangerZone dangerZone))
                return false;
        }

        return true;
    }
}