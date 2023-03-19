using System.Collections;
using UnityEngine;
using Assets;
using Storage.Dash;

namespace InputController.Components
{
    public class Dash
    {
        private const float DashDuration = 0.1f;
        private readonly LayerMask _layerMask = 1 << 3;

        public bool IsDashing;
        
        // ReSharper disable Unity.PerformanceAnalysis
        public void InitDashing(Rigidbody2D rb, Vector2 moveDirection)
        {
            if (!IsDashing && DashFacade.CanDash)
            {
                Coroutines.StartRoutine(DashRoutine(moveDirection, rb));
            }
        }

        private IEnumerator DashRoutine(Vector2 direction, Rigidbody2D rb)
        {
            IsDashing = true;
            DashFacade.IsCanDash(this, false);
            DashFacade.CurrentDashCountReduction(this, 1);

            var hit = Physics2D.Raycast(rb.position, direction, DashFacade.DashDistance, _layerMask);

            if (hit.collider is not null)
            {
                Debug.Log("Kill");
            }

            // Normalize the direction and apply the dash distance
            direction = direction.normalized * DashFacade.DashDistance;

            // Move the rigidbody by the dash distance
            rb.MovePosition(rb.position + direction);

            yield return new WaitForSeconds(DashDuration);
            IsDashing = false;

            if (DashFacade.CurrentDashCount == 0)
            {
                yield return new WaitForSeconds(DashFacade.DashCooldown - DashDuration);
                DashFacade.SetCurrentDashCount(this, DashFacade.MaxDashCount);
                DashFacade.IsCanDash(this, true);
            }
            else
            {
                yield return new WaitForSeconds(DashDuration - DashDuration);
            }

            // Apply a cooldown after dashing
            DashFacade.IsCanDash(this, true);
        }
    }
}