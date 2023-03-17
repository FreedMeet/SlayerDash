using System.Collections;
using Storage.Dash;
using UnityEngine;
using UnityEngine.UI;
using Assets;

namespace Views.PlayerView.DashUI
{
    public class DashCooldownUI : IDashObserver
    {
        private GameObject _cooldownPrefab;
        private readonly Text _dashCooldownText;
        private float _dashCooldown;

        private readonly GameObject _cooldownUI;

        private Coroutine _dashCooldownCoroutine;

        public DashCooldownUI(Canvas uiManager)
        {
            _cooldownUI = Object.Instantiate(Resources.Load<GameObject>("DashCooldownUIPrefab"), uiManager.transform);
            _dashCooldownText = _cooldownUI.GetComponentInChildren<Text>();

            DashFacade.AddObserver(this);
        }

        public void CreateDashCooldownUI()
        {
            UpdateDashCooldownText();
        }

        public void OnChange()
        {
            if (DashFacade.CanDash)
            {
                UpdateDashCooldownText();
                StopDashCooldownCoroutine();
            }
            else
            {
                StartDashCooldownCoroutine();
            }
        }

        private void UpdateDashCooldownText()
        {
            _dashCooldown = DashFacade.DashCooldown;
            _dashCooldownText.text = "Dash: Ready";
        }

        private void StartDashCooldownCoroutine()
        {
            if (_dashCooldownCoroutine == null)
            {
                _dashCooldownCoroutine = Coroutines.StartRoutine(DashCooldownRoutine());
            }
        }

        private void StopDashCooldownCoroutine()
        {
            if (_dashCooldownCoroutine != null)
            {
                Coroutines.StopRoutine(_dashCooldownCoroutine);
                _dashCooldownCoroutine = null;
            }
        }

        private IEnumerator DashCooldownRoutine()
        {
            while (!DashFacade.CanDash)
            {
                _dashCooldownText.text = $"Dash: {_dashCooldown:F1}";
                yield return new WaitForSeconds(1);
                _dashCooldown -= 1f;
            }

            StopDashCooldownCoroutine();
            UpdateDashCooldownText();
        }
        
        public void DestroyDashCountUI()
        {
            Object.Destroy(_cooldownUI);
            DashFacade.RemoveObserver(this);
            StopDashCooldownCoroutine();
        }
    }
}