using UnityEngine;

public class Mine : BaseEnemy
{
    [SerializeField] private SphereCollider thisCollider;

    [SerializeField] private float moveSpeed;
    private float directionDeviation;

    private float rotationDecider;
    [SerializeField] private float rotationDirection;
    [SerializeField] private float rotationSpeed;

    [SerializeField] private float blastRadius;

    override protected void Start()
    {
        base.Start();

        directionDeviation = Random.Range(-0.5f, 0.5f);

        rotationDecider = Random.Range(0, 2);
        if (rotationDecider >= 0.5f)
        {
            rotationDirection = -1;
        }
        else
        {
            rotationDirection = 1;
        }
    }

    protected override void OnUpdate()
    {
        transform.position += new Vector3(directionDeviation, 0, 1) * moveSpeed * Time.deltaTime;

        transform.Rotate(new Vector3(0,rotationDirection * rotationSpeed * Time.deltaTime, 0));

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