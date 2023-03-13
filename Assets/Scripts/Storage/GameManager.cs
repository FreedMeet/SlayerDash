using UnityEngine;

namespace Storage
{
    public class GameManager: MonoBehaviour
    {
        private void Start()
        {
           Game.Run();
           Game.OnGameInitializeEvent += OnGameInitializes;
        }

        private void OnGameInitializes()
        {
            Game.OnGameInitializeEvent -= OnGameInitializes;
            Debug.Log("GameRun");
        }
    }
}