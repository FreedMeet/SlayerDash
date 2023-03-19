using System;
using System.Collections;
using Assets;
using Scenes;
using Scenes.SceneManagers;

namespace Storage
{
    public static class Game
    {
        private static SceneManagerBase SceneManager { get; set; }
        public static event Action OnGameInitializeEvent;
    
        public static void Run()
        {
            SceneManager = new SceneManagerMain();
            Coroutines.StartRoutine(InitializeGameRoutine());
        }

        private static IEnumerator InitializeGameRoutine()
        {
            SceneManager.InitScenesMap();
            yield return SceneManager.LoadCurrentSceneAsync();
            OnGameInitializeEvent?.Invoke();
        }

        public static T GetIterator<T>() where T : Iterator
        {
            return SceneManager.GetIterator<T>();
        }

        public static T GetRepository<T>() where T : Repository
        {
            return SceneManager.GetRepository<T>();
        }
    }
}
