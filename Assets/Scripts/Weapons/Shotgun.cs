using UnityEngine;

public class Shotgun : Weapon
{
    private readonly int _pelletCount = 5;
    private readonly float _spreadAngle = 10f;

    public override void Shoot()
    {
        if (CanShoot())
        {
            for (int i = 0; i < _pelletCount; i++)
            {
                Vector3 direction = GetRandomDirectionInCone(transform.forward, _spreadAngle);

                if (Physics.Raycast(Shootpoint.position, direction, out RaycastHit hitInfo, Distance))
                {
                    Debug.DrawRay(Shootpoint.position, direction * hitInfo.distance, Color.red, 1f);

                    VisualizeEffectShoot();

                    if (hitInfo.collider.TryGetComponent(out Health health))
                    {
                        ApplyDamage(health);
                        print("Shoot shotgun");
                    }
                }
            }

            Timer.StartWork(SpeedShoot);
        }
    }

    private Vector3 GetRandomDirectionInCone(Vector3 forward, float angle)
    {
        float halfAngle = angle / 2;
        float randomAngle = Random.Range(-halfAngle, halfAngle);
        Quaternion rotation = Quaternion.Euler(0, randomAngle, 0);
        return rotation * forward;
    }
}
