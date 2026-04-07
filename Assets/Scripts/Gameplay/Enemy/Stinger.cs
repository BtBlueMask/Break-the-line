using Unity.Mathematics;
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
    [SerializeField] private float _MoveSpeed;

    private Quaternion _startRotation;
    private Quaternion _targetRotation;

    [SerializeField] float _rotationSpeed;

    override protected void Start()
    {
        base.Start();
        
        Quaternion temp = transform.rotation;
        temp.y = 180f;
        transform.rotation = temp; 
    }
    protected override void OnUpdate()
    {
        if (_Phase == EPhases.init)
        {
            Vector3 RelativePosition = transform.position - player.transform.position; 
            _startRotation = transform.rotation;
            _targetRotation = Quaternion.LookRotation(RelativePosition);

            _Phase = EPhases.rotating;
        }

        if (_Phase == EPhases.rotating)
        {
            Vector3 TargetDirection = (player.transform.position - transform.position).normalized;
            float angle = Vector3.Angle(transform.forward, TargetDirection);
            Vector3 newDirection = Vector3.RotateTowards(transform.forward, player.transform.position - transform.position , _rotationSpeed, 0f);

            transform.rotation = Quaternion.LookRotation(newDirection);

            //_rotationTimer += Time.deltaTime;
            //float percentage = _rotationTimer / _RotationDuration;
            //transform.rotation = Quaternion.Slerp(_startRotation,Quaternion.Euler(0, _targetRotation.y, 0) , percentage);
            //if (_rotationTimer >= _RotationDuration)
            //{
            //    transform.rotation = _targetRotation;
            //    _Phase = EPhases.moving;
            //}

            if (angle < 1f)
            {
                Debug.Log("rotating ended");
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
        player.OnPlayerDamaged(1);
    }

    protected override void OnProjectiletHit(Projectile projectile)
    {
        base.OnProjectiletHit(projectile);
    }
}
