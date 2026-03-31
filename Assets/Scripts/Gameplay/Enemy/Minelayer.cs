using UnityEngine;

public class Minelayer : BaseEnemy
{
    [SerializeField] private GameObject mine;
    [SerializeField] Transform mineSpawner;

    [SerializeField] private float mineDeployCooldownMax;
    [SerializeField]private float mineDeployCooldown = 0f;
    
    [SerializeField] private float moveSpeed;

    override protected void Start()
    {
        base.Start();
    }

    protected override void OnUpdate()
    {
        transform.position += Vector3.forward * moveSpeed * Time.deltaTime;

        mineDeployCooldown -= Time.deltaTime;
        if (mineDeployCooldown <= 0)
        {
            Instantiate(mine, mineSpawner.position, mineSpawner.rotation);
            mineDeployCooldown = mineDeployCooldownMax;
        }
    }

    protected override void OnPlayerHit(Player player)
    {
        Debug.Log("The player was hit");
        OnDeath();
    }

    protected override void OnProjectiletHit(Projectile projectile)
    {
        OnDeath();
    }
}
