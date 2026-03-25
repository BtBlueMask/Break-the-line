using UnityEngine;

public class BaseEnemy : MonoBehaviour
{
    [SerializeField] protected int health;
    [SerializeField] protected float moveSpeed;
    [SerializeField] protected int damage;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {


        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
