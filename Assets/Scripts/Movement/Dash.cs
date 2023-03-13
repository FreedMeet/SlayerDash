using System.Collections;
using UnityEngine;
using Assets;

namespace Movement
{
    public class Dash
{
    private const float DashDuration = 0.1f;
    private readonly LayerMask _layerMask = 1 << 3;

    public float dashDistance = 5f;
    public float dashCooldown = 10f;
    public int maxDashCount  = 5;

    public bool isDashing;
    public bool canDash = true;


    // ReSharper disable Unity.PerformanceAnalysis
    public void InitDashing(Rigidbody2D rb, Vector2 moveDirection)
    {
        if (!isDashing && canDash)
        {
            Coroutines.StartRoutine(DashRoutine(moveDirection, rb));
        }
    }

    private IEnumerator DashRoutine(Vector2 direction, Rigidbody2D rb)
    {
        isDashing = true;
        canDash = false;
        maxDashCount--;

        var hit = Physics2D.Raycast(rb.position, direction, dashDistance, _layerMask);
        
        if (hit.collider is not null)
        {
            Debug.Log("Kill");
        }

        // Normalize the direction and apply the dash distance
        direction = direction.normalized * dashDistance;

        // Move the rigidbody by the dash distance
        rb.MovePosition(rb.position + direction);

        yield return new WaitForSeconds(DashDuration);
        isDashing = false;
        
        if (maxDashCount == 0)
        {
            yield return new WaitForSeconds(dashCooldown - DashDuration);
            maxDashCount = 5;
            canDash = true;
        }
        else
        {
            yield return new WaitForSeconds(DashDuration - DashDuration);
        }

        // Apply a cooldown after dashing
        canDash = true;
    }
}
}
