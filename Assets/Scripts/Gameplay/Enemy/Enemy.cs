using UnityEngine;

public class Enemy : MonoBehaviour
{
    protected int health;

    protected float moveSpeed;

    protected int damage;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    //Checking to see if the enemy gets hit
    {


        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
