using UnityEngine;

public class GrenadeThrower : Weapon
{
    [SerializeField] private Grenade _grenadePrefab;

    private void Awake()
    {
        Init();
    }

    public override void Shoot()
    {
        if (CanShoot())
        {
            if (Physics.Raycast(ShootPoint.position, ShootPoint.forward, out RaycastHit hitInfo))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out RaycastHit hit))
                {
                    Instantiate(_grenadePrefab, transform.position, Quaternion.identity).Init(hit.point, transform);
                }

                Debug.DrawRay(ShootPoint.position, ShootPoint.forward * hitInfo.distance, Color.red, 1f);
            }

            Timer.StartWork(1f / SpeedShoot);
        }
    }
}