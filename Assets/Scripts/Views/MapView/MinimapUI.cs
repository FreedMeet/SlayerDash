using Storage.Room;
using UnityEngine;
using UnityEngine.UI;

namespace Views.MapView
{
    public class MinimapUI : IRoomObserver
    {
        private readonly Text _miniMap;

        private readonly GameObject _miniMapUI;

        public MinimapUI(Canvas uiManager)
        {
            _miniMapUI = Object.Instantiate(
                Resources.Load<GameObject>("UI/MiniMapUI"), uiManager.transform);
            _miniMap = _miniMapUI.GetComponentInChildren<Text>();
            
            RoomFacade.AddObserver(this);
        }

        public void CreateMinimapUI()
        {
            UpdateMiniMap();
        }
        
        private void UpdateMiniMap()
        {
            var text = "";
            foreach (var row in RoomFacade.MiniatureRoom)
            {
                string charListAsString = string.Join(" ", row);
                text += charListAsString + "\n";
            }

            _miniMap.text = text;
        }

        public void OnChange()
        {
            UpdateMiniMap();
        }

        public void DestroyMiniMapUI()
        {
            Object.Destroy(_miniMapUI);
            RoomFacade.RemoveObserver(this);
        }
    }
}