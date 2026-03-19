using UnityEngine;

public class Projectile : MonoBehaviour
{
    Rigidbody rb; // Reference to the Rigidbody component of the projectile

    [Header("Bullet Stats")]
    [Space]
    [Tooltip("Bullet Speed")]
    [SerializeField] private float speed = 10f;
    [Tooltip("Bullet Damage ")]
    [SerializeField] private float damage = 1f;
    [Tooltip("Bullet's lifetime")]
    [SerializeField] private float lifetime = 3f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }


    void Start()
    {
        ShootHandler(transform.forward, speed);



    }

    private void FixedUpdate()
    {

    }

    #region ShootHandler sumamry
    /// <summary>
    /// CurrentDirection can be "transform.forward" or any direction you want to shoot the projectile towards, and speed is the speed of the projectile.
    /// </summary>
    /// <param name="CurrentDirection"></param>
    /// <param name="speed"></param>
#endregion
    private void ShootHandler(Vector3 CurrentDirection, float speed)
    {
        rb.AddForce(CurrentDirection * speed); //CurrentDirection is the transform
        Destroy(gameObject, lifetime); // Destroy the projectile after its lifetime expires
    }






}

