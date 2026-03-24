using UnityEngine;

public class Stinger : Enemy
{
    private Vector3 _startPosition;


    private void Awake()
    {
        //Setting health
        health = 2;
        moveSpeed = 1;
        damage = 1;
    }

    void Start()
    {
        _startPosition = transform.position;
    }

    void Update()
    {
        
    }
}
