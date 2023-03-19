using UnityEngine;
using Views.PlayerView.ShootingUI;

namespace Views.PlayerView
{
    public class ShootView : View
    {
        private ShootReloadUI _shootReloadUI;
        private CountOfAmmoUI _countOfAmmoUI;
        private Canvas _uiManager;

        public override void OnCreate()
        {
            base.OnCreate();
            _uiManager = GameObject.FindObjectOfType<Canvas>();
        }

        public override void Initialize()
        {
            base.Initialize();
            _shootReloadUI = new ShootReloadUI(_uiManager);
            _countOfAmmoUI = new CountOfAmmoUI(_uiManager);
        }

        public override void OnStart()
        {
            base.OnStart();
            _shootReloadUI.CreateReloadTimeUI();
            _countOfAmmoUI.CreateCountOfShootUI();
        }
    }
}