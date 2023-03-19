using System.Collections;
using Assets;
using Storage.Shooting;
using UnityEngine;
using UnityEngine.UI;

namespace Views.PlayerView.ShootingUI
{
    public class ShootReloadUI : IShootingObserver
    {
        private GameObject _reloadTimePrefab;
        private readonly Text _reloadTimeText;
        private float _reloadTime;

        private readonly GameObject _reloadTimeUI;

        private Coroutine _reloadTimeCoroutine;

        public ShootReloadUI(Canvas uiManager)
        {
            _reloadTimeUI = Object.Instantiate(Resources.Load<GameObject>("ReloadTimeUIPrefab"), uiManager.transform);
            _reloadTimeText = _reloadTimeUI.GetComponentInChildren<Text>();

            ShootingFacade.AddObserver(this);
        }

        public void CreateReloadTimeUI()
        {
            UpdateReloadTimeText();
        }

        public void OnChange()
        {
            if (ShootingFacade.CanShoot)
            {
                UpdateReloadTimeText();
                StopReloadTimeCoroutine();
            }
            else if(!ShootingFacade.CanShoot && ShootingFacade.CurrentCountOfAmmo > 0)
            {
                UpdateReloadTimeText();
            }
            else
            {
                StartReloadTimeCoroutine();
            }
        }

        private void UpdateReloadTimeText()
        {
            _reloadTime = ShootingFacade.ReloadTime;
            _reloadTimeText.text = "Shoot: Ready";
        }

        private void StartReloadTimeCoroutine()
        {
            if (_reloadTimeCoroutine == null)
            {
                _reloadTimeCoroutine = Coroutines.StartRoutine(ReloadTimeRoutine());
            }
        }

        private void StopReloadTimeCoroutine()
        {
            if (_reloadTimeCoroutine != null)
            {
                Coroutines.StopRoutine(_reloadTimeCoroutine);
                _reloadTimeCoroutine = null;
            }
        }

        private IEnumerator ReloadTimeRoutine()
        {
            while (!ShootingFacade.CanShoot)
            {
                _reloadTimeText.text = $"Shoot: {_reloadTime:F1}";
                yield return new WaitForSeconds(0.1f);
                _reloadTime -= 0.1f;
            }

            StopReloadTimeCoroutine();
            UpdateReloadTimeText();
        }
        
        public void DestroyDashCountUI()
        {
            Object.Destroy(_reloadTimeUI);
            ShootingFacade.RemoveObserver(this);
            StopReloadTimeCoroutine();
        }
    }
}