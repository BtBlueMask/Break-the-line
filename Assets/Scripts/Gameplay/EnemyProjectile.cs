using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    Rigidbody rb; // Reference to the Rigidbody component of the projectile

    [Header("Bullet Stats")]
    [Space]
    [Tooltip("Bullet Speed")]
    [SerializeField] private float speed;
    [Tooltip("Bullet Damage ")]
    [SerializeField] private int damage = 1;
    [Tooltip("Bullet's lifetime")]
    [SerializeField] private int lifetime = 3;

    private Player player;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        player = FindFirstObjectByType<Player>();
    }


    void Start()
    {
        ShootHandler(transform.forward, speed);
    }

    private void FixedUpdate()
    {

    }

    /// <summary>
    /// 
    /// </summary>
    /// 
    /// <param name="CurrentDirection">CurrentDirection is a place holder for a direction (transform.forward)</param>
    /// <param name="speed">The bullet's speed</param>
    private void ShootHandler(Vector3 CurrentDirection, float speed)
    {
        rb.AddForce(CurrentDirection * speed); //CurrentDirection is the transform
        Destroy(gameObject, lifetime); // Destroy the projectile after its lifetime expires
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Player>())
        {
            player.OnPlayerDamaged(damage);
            Destroy(gameObject);
        }
    }
}

