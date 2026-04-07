using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{

    //Player State
    private enum EPlayerPhase
    {
        Alive,
        Dead
    }
    [SerializeField] private EPlayerPhase _PlayerPhase;

    //SerialzeFields
    [SerializeField] float _Speed = 1.0f;
    [SerializeField] float _AttackCooldown = 0.5f;
    [SerializeField] int _Lifes = 3;
    //Linked Prefabs
    [SerializeField] GameObject _Projectile;

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
        if (_Lifes > 0) { PlayerUpdate(); }
        else if (_PlayerPhase == EPlayerPhase.Alive)
        {
            OnDeath();
            _PlayerPhase = EPlayerPhase.Dead;
        }
    }

    protected void PlayerUpdate()
    {
        AttackIsPressed = fireAction.ReadValue<float>();
        Vector2 temp = moveAction.ReadValue<Vector2>();
        Vector3 input = new Vector3(temp.x, 0f, temp.y);
        movement = input * _Speed * Time.deltaTime;

        transform.localPosition = transform.localPosition + movement;

        if (AttackIsPressed == 1.0f && _AttackCooldown <= 0)
        {
            Instantiate(_Projectile, gameObject.transform.position, gameObject.transform.rotation);
            _AttackCooldown = 0.5f;
        }
        else
        {
            _AttackCooldown -= Time.deltaTime;
        }
    }

    private void OnDeath()
    {
        print("player died");
    }

    public void OnPlayerDamaged(int damage)
    {
        _Lifes -= damage;
    }

    #region Border
    private void BorderCheck()
    {
        
    }
    #endregion

}