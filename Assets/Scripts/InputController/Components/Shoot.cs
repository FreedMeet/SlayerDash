using System.Collections;
using Assets;
using Storage.Shooting;
using UnityEngine;

namespace InputController.Components
{
    public class Shoot
    {
        private const float BulletForce = 40f;
        private float _nextFireTime;
        private GameInput _gameInput;

        private readonly PoolMono<Bullet> _pool;

        public Shoot(Transform container)
        {
            _pool = new PoolMono<Bullet>(Resources.Load<Bullet>("Bullet"), 2, container);
        }

        public void InitShooting(Transform firePoint)
        {
            if (Time.time < _nextFireTime || !ShootingFacade.CanShoot) return;

            // Update the next fire time
            _nextFireTime = Time.time + ShootingFacade.FireRate;
            // Instantiate a bullet at the spawn point
            var bullet = _pool.GetFreeElement();

            bullet.transform.position = firePoint.position;
            
            var rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(firePoint.up * BulletForce, ForceMode2D.Impulse);
            
            ShootingFacade.CurrentCountOfAmmoReduction(this, 1);

            if (ShootingFacade.CurrentCountOfAmmo < 1)
            {
                Coroutines.StartRoutine(ShootReloadRoutine());
            }
        }

        private IEnumerator ShootReloadRoutine()
        {
            ShootingFacade.IsCanShoot(this, false);
            yield return new WaitForSeconds(ShootingFacade.ReloadTime);
            ShootingFacade.SetCurrentCountOfAmmo(this, ShootingFacade.CountOfAmmo);
            ShootingFacade.IsCanShoot(this, true);
        }
    } 
}

