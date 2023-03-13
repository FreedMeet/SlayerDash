using System;
using Storage;
using Storage.Dash;
using Storage.Player;
using UnityEngine;

namespace Movement
{
    public class MovementManager: MonoBehaviour, IControllable
    {
        private Move _move;
        private Dash _dash;
        private Rotate _rotation;

        private Rigidbody2D _rb;
        private Vector2 _moveDirection;
        
        
        private void Awake()
        {
            var playerIterator = Game.GetIterator<PlayerIterator>();
            var dashIterator = Game.GetIterator<DashIterator>();
            
            Debug.Log(dashIterator.MaxDashCount);
            
            _move = new Move(playerIterator);
            _dash = new Dash(dashIterator);
            _rotation = new Rotate();
        
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
    }
}