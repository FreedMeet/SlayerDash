using System;
using System.Collections;
using System.Collections.Generic;
using Assets;
using Storage;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scenes
{
    public abstract class SceneManagerBase
    {
        public event Action<Scene> OnSceneLoadingEvent;
        public Scene scene { get; private set; }
        public bool isLoading { get; private set; }
        protected Dictionary<string, SceneConfig> _sceneConfigMap;

        public SceneManagerBase()
        {
            _sceneConfigMap = new Dictionary<string, SceneConfig>();
            InitScenesMap();
        }

        public abstract void InitScenesMap();
        
        public Coroutine LoadCurrentSceneAsync()
        {
            if (isLoading)
                throw new Exception("Scene is loading now");

            var sceneName = SceneManager.GetActiveScene().name;
            var config = _sceneConfigMap[sceneName];
            return Coroutines.StartRoutine(LoadCurrentSceneRoutine(config));
        }

        private IEnumerator LoadCurrentSceneRoutine(SceneConfig sceneConfig)
        {
            isLoading = true;
            
            yield return Coroutines.StartRoutine(InitializeSceneRoutine(sceneConfig));
            
            isLoading = false;
            OnSceneLoadingEvent?.Invoke(scene);
        }

        public Coroutine LoadNewSceneAsync(string sceneName)
        {
            if (isLoading)
                throw new Exception("Scene is loading now");

            var config = _sceneConfigMap[sceneName];
            return Coroutines.StartRoutine(LoadNewSceneRoutine(config));
        }

        private IEnumerator LoadNewSceneRoutine(SceneConfig sceneConfig)
        {
            isLoading = true;
            
            yield return Coroutines.StartRoutine(LoadSceneRoutine(sceneConfig));
            yield return Coroutines.StartRoutine(InitializeSceneRoutine(sceneConfig));
            
            isLoading = false;
            OnSceneLoadingEvent?.Invoke(scene);
        }
        
        private IEnumerator LoadSceneRoutine(SceneConfig sceneConfig)
        {
            var async = SceneManager.LoadSceneAsync(sceneConfig.sceneName);
            async.allowSceneActivation = false;

            while (async.progress < 0.9f)
            {
                yield return null;
            }

            async.allowSceneActivation = true;
        }
        
        private IEnumerator InitializeSceneRoutine(SceneConfig sceneConfig)
        {
            scene = new Scene(sceneConfig);
            yield return scene.InitializeAsync();
        }

        public T GetRepository<T>() where T : Repository
        {
            return scene.GetRepository<T>();
        }
        
        public T GetIterator<T>() where T : Iterator
        {
            return scene.GetIterators<T>();
        }
    }
}