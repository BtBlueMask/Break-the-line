using UnityEngine;

public abstract class BaseEnemy : MonoBehaviour
{
    protected Player player;

    [SerializeField] protected int damage;

    [Header("Entry Parameters")]
    [SerializeField] private float entrySpeed;
    [SerializeField] private float entryTargetZ;
    private bool hasEntered = false;

    [SerializeField] private float borderBuffer;

    virtual protected void Start()
    {
        player = FindFirstObjectByType<Player>();
    }

    protected void Update()
    {
        if (!hasEntered)
        {
            if (transform.position.z > entryTargetZ)
            {
                OnEnterUpdate();
            }
            else
            {
                hasEntered = true;
                Debug.Log("Ship has entered the stage");
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
            Debug.Log("Projectile hit the enemy.");
        }
    }

    /// <summary>
    /// Is called when the enemy hits the player
    /// </summary>
    protected abstract void OnPlayerHit(Player player);

    /// <summary>
    /// Is called when the enemy hits a player-projectile
    /// </summary>
    protected virtual void OnProjectiletHit(Projectile projectile)
    {
        OnDeath();
    }

    /// <summary>
    /// Is called when the enemy should be destroyed
    /// </summary>
    protected virtual void OnDeath()
    {
        //gamemanager.RemoveEnemy
        Destroy(gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawLine(new Vector3(-10, 0, entryTargetZ), new Vector3(10, 0, entryTargetZ));
    }
}
