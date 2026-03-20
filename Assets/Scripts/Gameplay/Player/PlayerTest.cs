using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerTest : MonoBehaviour
{
    [SerializeField ]GameObject bulletPrefab;
    [SerializeField] private Transform firePoint;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (Keyboard.current.spaceKey.ReadValue() == 1)
        {
            GameObject go = Instantiate(bulletPrefab);
            go.transform.position = firePoint.localPosition;

        }
    }
}
