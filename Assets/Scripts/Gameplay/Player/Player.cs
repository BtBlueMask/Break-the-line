using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    //SerialzeFields
    [SerializeField] float _Speed = 1.0f;
    [SerializeField] float _AttackCooldown = 0.5f;

    //Input actions
    private InputAction fireAction;
    private InputAction moveAction;
    private float AttackIsPressed;

    private Vector3 movement;

    

    void Start()
    {
        fireAction = InputSystem.actions.FindAction("Attack");
        moveAction = InputSystem.actions.FindAction("Move");
    }



    void Update()
    {
        AttackIsPressed = fireAction.ReadValue<float>();
        Vector2 temp = moveAction.ReadValue<Vector2>();
        Vector3 input = new Vector3(temp.x, 0f, temp.y);
        movement = input * _Speed * Time.deltaTime;

        transform.localPosition = transform.localPosition + movement;

        if (AttackIsPressed == 1.0f && _AttackCooldown <= 0)
        {
            Debug.Log("bullet shot");
            _AttackCooldown = 0.5f;
        }
        else
        {
            _AttackCooldown -= Time.deltaTime;
        }
    }


}
