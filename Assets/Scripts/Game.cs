using System;
using System.Collections;
using Assets;
using Scenes;
using Storage;

public static class Game
{
    public static SceneManagerBase sceneManager { get; private set; }
    public static event Action OnGameInitializeEvent;
    
    public static void Run()
    {
        sceneManager = new SceneManagerMain();
        Coroutines.StartRoutine(InitializeGameRoutine());
    }

    private static IEnumerator InitializeGameRoutine()
    {
        sceneManager.InitScenesMap();
        yield return sceneManager.LoadCurrentSceneAsync();
        OnGameInitializeEvent?.Invoke();
    }

    public static T GetIterator<T>() where T : Iterator
    {
        return sceneManager.GetIterator<T>();
    }

    public static T GetRepository<T>() where T : Repository
    {
        return sceneManager.GetRepository<T>();
    }
}