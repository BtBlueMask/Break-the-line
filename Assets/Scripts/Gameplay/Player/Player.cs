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
    [SerializeField] Transform _BulletSpawner;

    //Input actions
    private InputAction fireAction;
    private InputAction moveAction;
    private float AttackIsPressed;

    private Vector3 movement;

    #region Border
    protected float minX;
    protected float maxX;
    protected float minZ;
    protected float maxZ;
    #endregion

    private GameManager gameManager;
    private SceneHanler sceneHanler;

    private HealthUI healthUI;

    void Start()
    {
        healthUI = FindFirstObjectByType<HealthUI>();
        gameManager = FindAnyObjectByType<GameManager>();
        sceneHanler = FindAnyObjectByType<SceneHanler>();

        #region Border
        Vector3 topRight = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, 20));
        Vector3 bottomLeft = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 20));

        minX = bottomLeft.x;
        maxX = topRight.x;
        minZ = bottomLeft.z;
        maxZ = topRight.z;
        #endregion

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
            Instantiate(_Projectile, _BulletSpawner.position, _BulletSpawner.rotation);
            _AttackCooldown = 0.5f;
        }
        else
        {
            _AttackCooldown -= Time.deltaTime;
        }
        BorderCheck();
    }

    private void OnDeath()
    {
        print("player died");
        gameManager.SaveScore();
        sceneHanler.LoadgameOver();
    }

    public void OnPlayerDamaged(int damage)
    {
        _Lifes -= damage;
        healthUI.onHealthChanged(_Lifes);
    }

    #region Border
    private void BorderCheck()
    {
        Vector3 pos = transform.position;

        if (pos.x < minX) { pos.x = minX;}
        else if (pos.x > maxX) { pos.x = maxX;}
        if (pos.z < minZ) { pos.z = minZ; }
        else if (pos.z > maxZ) { pos.z = maxZ;}

        transform.position = pos;
    }
    #endregion

}