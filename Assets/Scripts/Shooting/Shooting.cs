using UnityEngine;
using UnityEngine.InputSystem;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float fireRate = 0.5f;
    
    private const float BulletForce = 40f;
    private float _nextFireTime;
    private GameInput _gameInput;

    private void Awake()
    {
        _gameInput = new GameInput();
        _gameInput.Enable();
    }
    
    private void OnEnable()
    {
        _gameInput.Gameplay.Shoot.performed += OnShootPerformed;
    }

    private void OnShootPerformed(InputAction.CallbackContext obj)
    {
        Shoot();
    }

    private void OnDisable()
    {
        _gameInput.Gameplay.Dash.performed -= OnShootPerformed;
    }

    private void Shoot()
    {
        if (Time.time < _nextFireTime) return;
        
        // Update the next fire time
        _nextFireTime = Time.time + fireRate;

        // Instantiate a bullet at the spawn point
        var bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    
        var rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * BulletForce, ForceMode2D.Impulse);
            
        Destroy(bullet, .5f);
    }
}
