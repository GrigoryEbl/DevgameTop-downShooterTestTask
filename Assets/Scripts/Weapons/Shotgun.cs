using UnityEngine;

public class Shotgun : Weapon
{
    private readonly int _pelletCount = 5;
    private readonly float _spreadAngle = 10f;
    private float _distance = 7f;

    private void Awake()
    {
        Init();
    }

    public override void Shoot()
    {
        if (CanShoot())
        {
            VisualizeEffectShoot();

            for (int i = 0; i < _pelletCount; i++)
            {
                Vector3 direction = GetRandomDirectionInCone(transform.forward, _spreadAngle);

                if (Physics.Raycast(ShootPoint.position, direction, out RaycastHit hitInfo, _distance))
                {
                    Debug.DrawRay(ShootPoint.position, direction * hitInfo.distance, Color.red, 1f);

                    if (hitInfo.collider.TryGetComponent(out Health health))
                    {
                        ApplyDamage(health);
                        InvokEvent(health);
                    }
                }
            }

            Timer.StartWork(1f / SpeedShoot);
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