using System;
using System.Collections.Generic;
using Scenes;

namespace Storage
{
    public class RepositoryBase
    {
        private Dictionary<Type, Repository> _repositoriesMap;
        private readonly SceneConfig _sceneConfig;

        public RepositoryBase(SceneConfig sceneConfig)
        {
            _sceneConfig = sceneConfig;
        }

        public void CreateAllRepositories()
        {
            _repositoriesMap = _sceneConfig.CreateAllRepositories();
        }

        public void SendOnCreateToAllRepositories()
        {
            var allRepositories = _repositoriesMap.Values;
            foreach (var repository in allRepositories)
            {
                repository.OnCreate();
            }
        }
        
        public void InitializeAllRepositories()
        {
            var allRepositories = _repositoriesMap.Values;
            foreach (var repository in allRepositories)
            {
                repository.Initialize();
            }
        }
        
        public void SendOnstartToAllRepositories()
        {
            var allRepositories = _repositoriesMap.Values;
            foreach (var repository in allRepositories)
            {
                repository.OnStart();
            }
        }

        public T GetRepository<T>() where T : Repository
        {
            var type = typeof(T);
            return (T)_repositoriesMap[type];
        }
    }
}