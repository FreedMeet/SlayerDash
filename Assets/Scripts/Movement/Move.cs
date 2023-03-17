using Storage.Player;
using UnityEngine;

namespace Movement
{
    public class Move
    {
        public void InitMoving(Rigidbody2D rb, Vector2 moveDirection)
        {
            rb.MovePosition(rb.position + PlayerFacade.MoveSpeed * moveDirection * Time.fixedDeltaTime);
        }
    }
}
