using UnityEngine;

namespace InputController.Components
{
    public class Rotate
    {
        public void InitRotation(Rigidbody2D rb, Vector2 mousePosition)
        {
            // Calculate the direction to face
            var direction = mousePosition - rb.position;

            // Calculate the angle in degrees between the player and the mouse
            var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;

            // Rotate the player to face the mouse
            rb.rotation = angle;
        }
    }
}