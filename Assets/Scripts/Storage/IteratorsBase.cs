using System;
using System.Collections.Generic;
using Scenes;

namespace Storage
{
    public class IteratorsBase
    {
        private Dictionary<Type, Iterator> _iteratorsMap;
        private SceneConfig _sceneConfig;

        public IteratorsBase(SceneConfig sceneConfig)
        {
            _sceneConfig = sceneConfig;
        }

        public void CreateAllIterators()
        {
            _iteratorsMap = _sceneConfig.CreateAllIterators();
        }

        public void SendOnCreateToAllIterators()
        {
            var allIterators = _iteratorsMap.Values;
            foreach (var iterator in allIterators)
            {
                iterator.OnCreate();
            }
        }
        
        public void InitializeAllIterators()
        {
            var allIterators = _iteratorsMap.Values;
            foreach (var iterator in allIterators)
            {
                iterator.Initialize();
            }
        }
        
        public void SendOnstartToAllIterators()
        {
            var allIterators = _iteratorsMap.Values;
            foreach (var iterator in allIterators)
            {
                iterator.OnStart();
            }
        }

        public T GetIterator<T>() where T : Iterator
        {
            var type = typeof(T);
            return (T)_iteratorsMap[type];
        }
    }
}