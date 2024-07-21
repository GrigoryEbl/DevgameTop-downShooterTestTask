
public class SpeedBoostBonus : Bonus
{ 
   private void Start()
    {
        BonusType = BonusType.SpeedBoost;
    }

    public override void ApplyEffect(Player player)
    {
        player.StartCoroutine(player.SpeedBoost(Duration));
        Destroy(gameObject); 
    }
}
