using UnityEngine;

public class Minelayer : BaseEnemy
{
    [SerializeField] private GameObject mine;
    [SerializeField] Transform mineSpawner;

    [SerializeField] private float mineDeployCooldownMax;
    [SerializeField]private float mineDeployCooldownCurrent = 0f;
    
    [SerializeField] private float moveSpeed;

    override protected void Start()
    {
        base.Start();
    }

    protected override void OnUpdate()
    {
        transform.position += Vector3.forward * moveSpeed * Time.deltaTime;

        mineDeployCooldownCurrent -= Time.deltaTime;
        if (mineDeployCooldownCurrent <= 0)
        {
            Instantiate(mine, mineSpawner.position, mineSpawner.rotation);
            mineDeployCooldownCurrent = mineDeployCooldownMax;
        }
    }

    protected override void OnPlayerHit(Player player)
    {
        Debug.Log("The player was hit");
        player.OnPlayerDamaged(damage);
        manager.UpdateScore(givenScore);
        OnDeath();
    }

    protected override void OnProjectiletHit(Projectile projectile)
    {
        base.OnProjectiletHit(projectile);
    }
}
