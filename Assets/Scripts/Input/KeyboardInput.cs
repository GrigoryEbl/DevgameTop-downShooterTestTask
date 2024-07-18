using UnityEngine;

[RequireComponent(typeof(Mover))]
public class KeyboardInput : MonoBehaviour
{
    private Mover _mover;

    private void Awake()
    {
        _mover = GetComponent<Mover>();
    }

    private void Update()
    {
        Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        _mover.Move(direction);
    }
}
