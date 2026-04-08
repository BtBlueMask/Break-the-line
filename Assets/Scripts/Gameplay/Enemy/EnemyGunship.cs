using UnityEngine;

public class EnemyGunship : BaseEnemy
{
    //Enemy Shooting related
    [SerializeField] private float _ShootingCD;
    private float ShootTimer;

    [SerializeField] private GameObject enemyBullet;

    [SerializeField] private Transform gun1;
    [SerializeField] private Transform gun2;
    private int preparedGun = 0;

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
        if (transform.position.x >= maxX - borderBuffer || transform.position.x <= minX + borderBuffer)
        {
            moveDirection = moveDirection * -1;
        }

        ShootTimer += Time.deltaTime;
        if (ShootTimer >= _ShootingCD)
        {
            ShootTimer = 0;
            if (preparedGun == 0)
            {
                Instantiate(enemyBullet, gun1.position, gun1.rotation);
                preparedGun = 1;
            }
            else if (preparedGun == 1)
            {
                Instantiate(enemyBullet, gun2.position, gun2.rotation);
                preparedGun = 0;
            }
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
