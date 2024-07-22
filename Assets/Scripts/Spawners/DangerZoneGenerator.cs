
using System.Collections.Generic;

using UnityEngine;

public class DangerZoneGenerator : MonoBehaviour
{
    [SerializeField] private DangerZone[] _dangerZonesPrefabs;
    [SerializeField] private Transform _spawnPoints;
    [SerializeField] private LayerMask obstacleLayer;
    [SerializeField] private float _minDistance = 6;

    private Transform _spawnPoint;
    private float _scanObstacleRadius = 9f;
    private List<Vector3> _positions = new List<Vector3>();

    private void Awake()
    {
        Generate();
    }

    public void Generate()
    {

        Vector3 newPosition;
        int attempts = 0;
        float maxX = 20f;
        float minX = -20f;
        float maxZ = 15f;
        float minZ = -15f;


        for (int i = 0; i < _dangerZonesPrefabs.Length; i++)
        {
            do
            {
                newPosition = new Vector3(Random.Range(minX, maxX), 1, (Random.Range(minZ, maxZ)));
                attempts++;
            }
            while (!IsValidPosition(newPosition) && attempts < 100);
            {
                if (attempts < 100)
                {
                    _positions.Add(newPosition);
                    Instantiate(_dangerZonesPrefabs[i], newPosition, Quaternion.identity);
                }
                else
                {
                    print("ERRORRRRR");
                }
            }
        }
    }

    private bool IsValidPosition(Vector3 position)
    {
        foreach (var existingPosition in _positions)
        {
            if (Vector3.Distance(position, existingPosition) < _minDistance)
            {
                return false;
            }
        }

        Collider[] hitColliders = Physics.OverlapSphere(position, _minDistance, obstacleLayer);

        if (hitColliders.Length > 0)
        {
            return false;
        }

        return true;
    }
}