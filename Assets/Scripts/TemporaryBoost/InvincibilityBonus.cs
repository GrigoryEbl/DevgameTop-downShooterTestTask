

public class InvincibilityBonus : Bonus
{
    void Start()
    {
        BonusType = BonusType.Invincibility;
    }

    public override void ApplyEffect(Player player)
    {
        player.StartCoroutine(player.Invincibility(Duration));
        Destroy(gameObject); 
    }
}
