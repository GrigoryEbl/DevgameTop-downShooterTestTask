using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof (NavMeshAgent))]
public class EnemyInput : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Transform _target;
    private NavMeshAgent _agent;

    private void Awake()
    {
        _target = FindAnyObjectByType<Player>().transform;
        _agent = GetComponent<NavMeshAgent>();
        _agent.speed = _speed;
    }

    private void Update()
    {
        if (_target != null)
            SetTarget();
    }

    private void SetTarget()
    {
        _agent.SetDestination(_target.position);
    }
}