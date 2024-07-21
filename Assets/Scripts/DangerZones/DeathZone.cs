using System.Collections;
using System.Collections.Generic;
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
        Destroy(player.gameObject);
    }
}
