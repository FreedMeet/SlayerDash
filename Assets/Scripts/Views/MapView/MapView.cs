using UnityEngine;

namespace Views.MapView
{
    public class MapView : View
    {
        private MinimapUI _miniMapUI;
        private Canvas _uiManager;

        public override void OnCreate()
        {
            base.OnCreate();
            _uiManager = GameObject.FindObjectOfType<Canvas>();
        }

        public override void Initialize()
        {
            base.Initialize();
            _miniMapUI = new MinimapUI(_uiManager);
        }

        public override void OnStart()
        {
            base.OnStart();
            _miniMapUI.CreateMinimapUI();
        }
    }
}