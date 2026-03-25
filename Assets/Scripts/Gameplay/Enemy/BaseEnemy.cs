using UnityEngine;

public abstract class BaseEnemy : MonoBehaviour
{
    protected Player player;

    [SerializeField] protected int damage;

    [Header("Entry Parameters")]
    [SerializeField] private float entrySpeed;
    [SerializeField] private float entryTargetY;
    private bool hasEntered = false;

    [SerializeField] private float borderBuffer;

    private void Start()
    {
        player = FindFirstObjectByType<Player>();
    }

    protected void Update()
    {
        if (!hasEntered)
        {
            if (transform.position.y < entryTargetY)
            {
                OnEnterUpdate();
            }
            else
            {
                hasEntered = true;
            }
        }
        else
        {
            OnUpdate();
            // TODO: Border Check
        }
    }

    private void OnEnterUpdate()
    {
        transform.position += Vector3.forward * entrySpeed * Time.deltaTime;
    }

    protected abstract void OnUpdate();

    private void OnTriggerEnter(Collider other)
    {
        Player player = other.GetComponent<Player>();
        if (player != null)
        {
            OnPlayerHit(player);
            OnDeath();
        }

        Projectile projectile = other.GetComponent<Projectile>();
        if (projectile != null)
        {
            OnProjectiletHit(projectile);
        }
    }

    /// <summary>
    /// Is called when the enemy hits the player
    /// </summary>
    protected abstract void OnPlayerHit(Player player);

    /// <summary>
    /// Is called when the enemy hits a player-projectile
    /// </summary>
    protected abstract void OnProjectiletHit(Projectile projectile);

    /// <summary>
    /// Is called when the enemy should be destroyed
    /// </summary>
    protected virtual void OnDeath()
    {
        Destroy(gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawLine(new Vector3(-10, 0, entryTargetY), new Vector3(10, 0, entryTargetY));
    }
}
