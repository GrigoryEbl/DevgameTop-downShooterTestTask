using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int _value;

    public void TakeDamage(int damage)
    {
        if (damage > 0)
            _value -= damage;

        if (_value <= 0)
        {
            _value = 0;
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}