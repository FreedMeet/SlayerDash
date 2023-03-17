using Storage.Dash;
using UnityEngine;
using Views.PlayerView.DashUI;

namespace Views.PlayerView
{
    public class DashView : View
    {

        private DashCooldownUI _dashCooldownUI;
        private DashCountUI _dashCountUI;
        private Canvas _uiManager;

        public override void OnCreate()
        {
            base.OnCreate();
            _uiManager = GameObject.FindObjectOfType<Canvas>();
        }

        public override void Initialize()
        {
            base.Initialize();
            _dashCooldownUI = new DashCooldownUI(_uiManager);
            _dashCountUI = new DashCountUI(_uiManager);
        }

        public override void OnStart()
        {
            base.OnStart();
            _dashCooldownUI.CreateDashCooldownUI();
            _dashCountUI.CreateDashCountUI();
        }
    }
}