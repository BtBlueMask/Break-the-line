using UnityEngine;

public class EnemyGunship : BaseEnemy
{
    //Enemy Shooting related
    [SerializeField] private float _ShootingCD;
    private float ShootTimer;

    //Enemy movement related
    private float moveDirectionDecider;
    [SerializeField] private float moveDirection;
    [SerializeField] private float moveSpeed;

    protected override void Start()
    {
        base.Start();

        moveDirectionDecider = Random.Range(0, 2);
        if (moveDirectionDecider >= 0.5)
        {
            moveDirection = 1;
        }
        else
        {
            moveDirection = -1;
        }
    }

    protected override void OnUpdate()
    {
        transform.position += new Vector3(moveDirection * moveSpeed * Time.deltaTime, 0, 0);
        //if (/* Check if enemy gets too close to border */)
        //{
        //    moveDirection = moveDirection * -1;
        //}

        ShootTimer += Time.deltaTime;
        if (ShootTimer >= _ShootingCD)
        {
            //Instantiate('bullet type for enemy');
        }
    }

    protected override void OnPlayerHit(Player player)
    {
        Destroy(gameObject);
    }

    protected override void OnProjectiletHit(Projectile projectile)
    {
        Destroy(gameObject);
    }
}
