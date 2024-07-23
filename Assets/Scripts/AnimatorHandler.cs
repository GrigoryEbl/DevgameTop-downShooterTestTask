using UnityEngine;

public class AnimatorHandler : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private Mover _mover;

    private string _parameterName = "IsRun";

    private void OnEnable() => _mover.Moved += SetState;

    private void OnDisable() => _mover.Moved -= SetState;

    private void SetState(bool value)
    {
        _animator.SetBool(_parameterName, value);
    }
}