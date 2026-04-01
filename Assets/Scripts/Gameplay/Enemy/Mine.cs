using UnityEngine;

public class Mine : BaseEnemy
{
    [SerializeField] private SphereCollider thisCollider;

    [SerializeField] private float moveSpeed;
    private float directionDeviation;

    [SerializeField] private float blastRadius;

    override protected void Start()
    {
        base.Start();

        directionDeviation = Random.Range(-0.5f, 0.5f);
    }

    protected override void OnUpdate()
    {
        transform.position += new Vector3(directionDeviation, 0, 1) * moveSpeed * Time.deltaTime;
    }

    protected override void OnPlayerHit(Player player)
    {
        Debug.Log("The player was hit");
        MineExplode();
        OnDeath();
    }

    protected override void OnProjectiletHit(Projectile projectile)
    {
        MineExplode();
        OnDeath();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, blastRadius);
    }

    private void MineExplode()
    {
        thisCollider.radius = blastRadius;
    }
}