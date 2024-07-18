using UnityEngine;

[RequireComponent(typeof(Mover))]
public class PlayerInput : MonoBehaviour
{
    private Mover _mover;
    private Quaternion _targetRotation;

    private void Awake()
    {
        _mover = GetComponent<Mover>();
    }

    private void Update()
    {
        Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        _mover.Move(direction);

        if (Input.GetMouseButton(0))
            _mover.Rotate(GetTargetDirection());
    }

    private Quaternion GetTargetDirection()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            _targetRotation = Quaternion.LookRotation(hit.point - transform.position, Vector3.up);
        }

        return _targetRotation;
    }
}
