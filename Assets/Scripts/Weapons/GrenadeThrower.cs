using TMPro;
using UnityEngine;

public class GrenadeThrower : Weapon
{
    [SerializeField] private Grenade _grenadePrefab;

    public override void Shoot()
    {
        if (CanShoot())
        {
            if (Physics.Raycast(ShootPoint.position, ShootPoint.forward, out RaycastHit hitInfo))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out RaycastHit hit))
                {
                    Instantiate(_grenadePrefab, transform.position, Quaternion.identity).Init(hit.point);
                }

                Debug.DrawRay(ShootPoint.position, ShootPoint.forward * hitInfo.distance, Color.red, 1f);
            }

            Timer.StartWork(1f / SpeedShoot);
        }
    }
}
