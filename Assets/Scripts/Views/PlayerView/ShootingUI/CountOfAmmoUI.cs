using Storage.Shooting;
using UnityEngine;
using UnityEngine.UI;

namespace Views.PlayerView.ShootingUI
{
    public class CountOfAmmoUI : IShootingObserver
    {
        private readonly Text _countOfAmmoText;

        private readonly GameObject _countOfAmmoUI;

        public CountOfAmmoUI(Canvas uiManager)
        {
            _countOfAmmoUI = Object.Instantiate(
                Resources.Load<GameObject>("UI/CountOfAmmoUIPrefab"), uiManager.transform);
            _countOfAmmoText = _countOfAmmoUI.GetComponentInChildren<Text>();

            ShootingFacade.AddObserver(this);
        }

        public void CreateCountOfShootUI()
        {
            UpdateCountOfAmmoText();
        }

        private void UpdateCountOfAmmoText()
        {
            _countOfAmmoText.text =
                $"Ammo: {ShootingFacade.CurrentCountOfAmmo:F0} / {ShootingFacade.CountOfAmmo:F0}";
        }

        public void OnChange()
        {
            UpdateCountOfAmmoText();
        }

        public void DestroyDashCountUI()
        {
            Object.Destroy(_countOfAmmoUI);
            ShootingFacade.RemoveObserver(this);
        }
    }
}