using System.Transactions;
using UnityEngine;

public class EnemyGunship : BaseEnemy
{
    //States
    private enum EPhases
    {
        init,
        rotating,
        moving
    }

    [SerializeField] private EPhases _Phase;

    //Player tracking related
    Transform PlayerTransform;

    //Enemy Shooting related
    [SerializeField] float _ShootingCD;
    float ShootTimer;


    protected override void Start()
    {
        base.Start();
        PlayerTransform = player.transform;

    }

    protected override void OnUpdate()
    {
        ShootTimer += Time.deltaTime;
        if (ShootTimer >= _ShootingCD)
        {
            //Instantiate('bullet type for enemy');
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
