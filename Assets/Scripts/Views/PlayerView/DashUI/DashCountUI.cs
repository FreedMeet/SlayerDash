using Storage.Dash;
using UnityEngine;
using UnityEngine.UI;

namespace Views.PlayerView.DashUI
{
    public class DashCountUI: IDashObserver
    {
        private readonly Text _dashCountText;

        private readonly GameObject _dashCountUI;

        public DashCountUI(Canvas uiManager)
        {
            _dashCountUI = Object.Instantiate(
                Resources.Load<GameObject>("DashCountUIPrefab"), uiManager.transform);
            _dashCountText = _dashCountUI.GetComponentInChildren<Text>();
            
            DashFacade.AddObserver(this);
        }

        public void CreateDashCountUI()
        {
            UpdateDashCountText();
        }
        
        private void UpdateDashCountText()
        {
            _dashCountText.text = $"Dash Count: {DashFacade.CurrentDashCount:F0} / {DashFacade.MaxDashCount:F0}";
        }

        public void OnChange()
        {
            UpdateDashCountText();
        }

        public void DestroyDashCountUI()
        {
            Object.Destroy(_dashCountUI);
            DashFacade.RemoveObserver(this);
        }
    }
}