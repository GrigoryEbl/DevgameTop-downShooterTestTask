using UnityEngine;

public class SlowingZone : DangerZone
{
    private float _startSpeed;
    private float _decreaseSpeed;
    private Mover _mover;
    private bool _isCathced = false;
    private float _speedFactor = 0.6f;

    private void OnTriggerEnter(Collider other)
    {
        if (_isCathced == false)
            if (other.TryGetComponent(out Player player))
            {
                _isCathced = true;
                ApplyEffect(player);
            }
    }

    private void OnTriggerExit(Collider other)
    {
        if (_mover != null)
        {
            _mover.ChangeSpeed(_startSpeed);
            _isCathced = false;
        }
    }

    public override void ApplyEffect(Player player)
    {
        if (player.TryGetComponent(out Mover mover))
        {
            _mover = mover;
            _startSpeed = _mover.CurrentSpeed;
            _decreaseSpeed = _mover.CurrentSpeed -_mover.CurrentSpeed * _speedFactor;

            _mover.ChangeSpeed(_decreaseSpeed);
        }
    }
}
