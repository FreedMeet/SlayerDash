using System.Collections;
using UnityEngine;
using Assets;
using Storage.Dash;

namespace Movement
{
    public class Dash
    {
        private const float DashDuration = 0.1f;
        private readonly LayerMask _layerMask = 1 << 3;
        private readonly DashIterator _dashIterator;

        public Dash(DashIterator iterator)
        {
            _dashIterator = iterator;
        }

        public bool IsDashing;
        
        // ReSharper disable Unity.PerformanceAnalysis
        public void InitDashing(Rigidbody2D rb, Vector2 moveDirection)
        {
            if (!IsDashing && _dashIterator.CanDash)
            {
                Coroutines.StartRoutine(DashRoutine(moveDirection, rb));
            }
        }

        private IEnumerator DashRoutine(Vector2 direction, Rigidbody2D rb)
        {
            IsDashing = true;
            DashFacade.IsCanDash(this, false);
            DashFacade.CurrentDashCountReduction(this, 1);

            var hit = Physics2D.Raycast(rb.position, direction, _dashIterator.DashDistance, _layerMask);

            if (hit.collider is not null)
            {
                Debug.Log("Kill");
            }

            // Normalize the direction and apply the dash distance
            direction = direction.normalized * _dashIterator.DashDistance;

            // Move the rigidbody by the dash distance
            rb.MovePosition(rb.position + direction);

            yield return new WaitForSeconds(DashDuration);
            IsDashing = false;

            if (_dashIterator.CurrentDashCount == 0)
            {
                yield return new WaitForSeconds(_dashIterator.DashCooldown - DashDuration);
                DashFacade.SetCurrentDashCount(this, _dashIterator.MaxDashCount);
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