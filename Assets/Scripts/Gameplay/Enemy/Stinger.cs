using System.Runtime.CompilerServices;
using Unity.Mathematics;
using UnityEngine;

public class Stinger : Enemy
{

    //Player Simulation (Delete when merged)
    private Vector3 PlayerPos = Vector3.zero;
    //End of Player simulation variables

    //Other test variables
    private float RotationTime = 5;
    private float RotationTimer = 0;

    private Quaternion TargetRotation;
    private Vector3 _startPosition;
    private quaternion TargetDirection;
    private enum EPhase
    {
        Positioning = 0,
        Rotating = 1,
        Launching = 3
    }



    private void Awake()
    {
        //Setting health
        health = 2;
        moveSpeed = 1f;
        damage = 1;
    }

    void Start()
    {
        _startPosition = transform.position;
        //TargetRotation = Quaternion.Euler(); !! vector3 has to be a rotation that looks at the players position.
        TargetDirection = FindLookDirection(PlayerPos);
    }

    void Update()
    {
        //float DeltaSpeed = moveSpeed * Time.deltaTime;
        //transform.position += -transform.forward * moveSpeed * Time.deltaTime;

        //Update timers
        RotationTimer += Time.deltaTime;
        float percentage = RotationTimer / RotationTime;
        transform.rotation = Quaternion.Slerp(Quaternion.Euler(0, 0, 0), TargetDirection, percentage);
    }

    private Quaternion FindLookDirection(Vector3 PlayerPosition)
    {
        return Quaternion.LookRotation(PlayerPosition);
    }
}