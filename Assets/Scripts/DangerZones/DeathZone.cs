using UnityEngine;

public class DeathZone : DangerZone
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            ApplyEffect(player);
        }
    }

    public override void ApplyEffect(Player player)
    {
        player.Die();
    }
}