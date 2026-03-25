using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class Stinger : Enemy
{

    //Player Simulation (Delete when merged)
    private Vector3 PlayerPos = Vector3.zero;
    //End of Player simulation variables

    //Other test variables
    private float RotationTime = 1;
    private float MoveTime = 1;
    private float MoveTimer = 0;

    private Vector3 StartPosition;
    private Vector3 EndPosition;

    private Quaternion StartRotation;
    private Quaternion TargetRotation;
    private Quaternion TargetDirection;
    private enum EPhase
    {
        Positioning = 0,
        Rotating,
        Launching,
    }
    [SerializeField] private EPhase _Phase;



    private void Awake()
    {
        
        //Setting health
        health = 2;
        moveSpeed = 100f;
        damage = 1;
    }

    void Start()
    {
        //First phase movement variables
        StartPosition = transform.position;
        EndPosition = new Vector3(StartPosition.x, StartPosition.y, Random.Range(7f,9f));

        //Second Phase movement variables
        StartRotation = transform.rotation;
    }

    void Update()
    {

        if (_Phase == EPhase.Positioning)
        {
            float MovePercentage = MoveTimer / MoveTime;
            transform.position = Vector3.Lerp(StartPosition,EndPosition, MovePercentage);
            if (EndPosition == transform.position)
            {
                MoveTimer = 0;
                TargetDirection = FindLookDirection(PlayerPos);
                _Phase = EPhase.Rotating;
            }
        }

        //float DeltaSpeed = moveSpeed * Time.deltaTime;
        //transform.position += -transform.forward * moveSpeed * Time.deltaTime;

        //Update timers
        MoveTimer += Time.deltaTime;


        //Rotation logic
        if (_Phase == EPhase.Rotating)
        {
            float percentage = MoveTimer / RotationTime;
            transform.rotation = Quaternion.Slerp(StartRotation, TargetDirection, percentage);
            if (TargetDirection == transform.rotation)
            {
                _Phase = EPhase.Launching;
            }
        }

        if (_Phase == EPhase.Launching)
        {
            transform.position += transform.forward * moveSpeed * Time.deltaTime;
        }
    }

    private Quaternion FindLookDirection(Vector3 PlayerPosition)
    {
        Vector3 RelativePosition = PlayerPosition - transform.position;
        return Quaternion.LookRotation(RelativePosition);
    }
}