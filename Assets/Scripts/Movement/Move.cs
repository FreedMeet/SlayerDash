using Storage.Player;
using UnityEngine;

namespace Movement
{
    public class Move
    {
        private readonly PlayerIterator _playerIterator;

        public Move(PlayerIterator iterator)
        {
            _playerIterator = iterator;
        }

        public void InitMoving(Rigidbody2D rb, Vector2 moveDirection)
        {
            rb.MovePosition(rb.position + _playerIterator.MoveSpeed * moveDirection * Time.fixedDeltaTime);
        }
    }
}
