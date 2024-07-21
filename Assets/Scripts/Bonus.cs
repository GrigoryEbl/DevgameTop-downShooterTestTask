using UnityEngine;

public class Bonus : MonoBehaviour
{
    [SerializeField] private Timer _timer;

    private float _lifeTime = 5f;

    private void Awake()
    {
        _timer.StartWork(_lifeTime);
        transform.position = new Vector3(transform.position.x, 1, transform.position.z);
    }

    private void OnEnable()
    {
        _timer.TimeEmpty += DestroySelf;
    }

    private void OnDisable()
    {
        _timer.TimeEmpty -= DestroySelf;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player))
            enabled = false;
    }

    private void DestroySelf()
    {
        Destroy(gameObject);
    }
}
