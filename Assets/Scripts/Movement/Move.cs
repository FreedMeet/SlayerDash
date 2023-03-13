using UnityEngine;

namespace Movement
{
    public class Move
    {
        private float moveSpeed = 5f;

        public void InitMoving(Rigidbody2D rb, Vector2 moveDirection)
        {
            rb.MovePosition(rb.position + moveSpeed * moveDirection * Time.fixedDeltaTime);
        }
    }
}
