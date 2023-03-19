using System;
using InputController.Components;
using UnityEngine;

namespace InputController
{
    public class MovementManager: MonoBehaviour, IControllable
    {
        private Move _move;
        private Dash _dash;
        private Rotate _rotation;
        private Shoot _shoot;

        private Rigidbody2D _rb;
        private Vector2 _moveDirection;


        private void Awake()
        {
            var container = GetComponent<Transform>().Find("BulletContainer");
            
            _move = new Move();
            _dash = new Dash();
            _rotation = new Rotate();
            
            _shoot = new Shoot(container);

            if (_move is null && _dash is null && _rotation is null)
                throw new Exception($"there is no components on the object {gameObject.name}");
        }


        public void Move(Vector2 direction, Rigidbody2D rb)
        {
            if (_dash.IsDashing) return;
            _move.InitMoving(rb, direction);
        }

        public void Dash(Vector2 direction, Rigidbody2D rb)
        {
            _dash.InitDashing(rb, direction);
        }

        public void Rotation(Vector2 direction, Rigidbody2D rb)
        {
            _rotation.InitRotation(rb, direction);
        }

        public void Shoot(Transform firePoint)
        {
            _shoot.InitShooting(firePoint);
        }
    }
}