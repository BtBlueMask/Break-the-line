using UnityEngine;

public class Stinger : BaseEnemy
{
    private enum EPhases
    {
        init,
        rotating,
        moving
    }

    [SerializeField] private EPhases _Phase;

    [SerializeField] private float _RotationDuration = 1f;
    private float _rotationTimer = 0;
    [SerializeField] private float _MoveSpeed;

    private Quaternion _startRotation;
    private Quaternion _targetRotation;


    protected override void OnUpdate()
    {
        if (_Phase == EPhases.init)
        {
            _rotationTimer = 0;

            Vector3 RelativePosition = player.transform.position - transform.position;
            _startRotation = transform.rotation;
            _targetRotation = Quaternion.LookRotation(RelativePosition);

            _Phase = EPhases.rotating;
        }

        if (_Phase == EPhases.rotating)
        {
            _rotationTimer += Time.deltaTime;
            float percentage = _rotationTimer / _RotationDuration;
            transform.rotation = Quaternion.Slerp(_startRotation, _targetRotation, percentage);
            if (_rotationTimer >= _RotationDuration)
            {
                transform.rotation = _targetRotation;
                _Phase = EPhases.moving;
            }
            return;
        }

        if (_Phase == EPhases.moving)
        {
            transform.position += -transform.forward * _MoveSpeed * Time.deltaTime;
        }
    }

    protected override void OnPlayerHit(Player player)
    {
        throw new System.NotImplementedException();
    }

    protected override void OnProjectiletHit(Projectile projectile)
    {
        throw new System.NotImplementedException();
    }
}
