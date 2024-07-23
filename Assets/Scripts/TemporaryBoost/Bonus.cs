using UnityEngine;

public enum BonusType
{
    Weapon,
    SpeedBoost,
    Invincibility
}

public abstract class Bonus : MonoBehaviour
{
    public BonusType BonusType;

    private float _lifeTime = 5f;
    private float _duration = 10f;

    public float Duration => _duration;

    private void Awake()
    {
        transform.position = new Vector3(transform.position.x, 1, transform.position.z);
        Destroy(gameObject, _lifeTime);
    }

    public abstract void ApplyEffect(Player player);
}