using UnityEngine;

public class WeaponBonus : Bonus
{
    [SerializeField] private Weapon _weaponPrefab;

    void Start()
    {
        BonusType = BonusType.Weapon;
    }

    public override void ApplyEffect(Player player)
    {
        player.SetWeapon(_weaponPrefab);
        Destroy(gameObject);
    }
}
