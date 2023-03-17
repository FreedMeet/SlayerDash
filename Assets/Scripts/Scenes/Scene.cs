using System.Collections;
using Assets;
using Storage;
using UnityEngine;
using Views;

namespace Scenes
{
    public class Scene
    {
        private readonly IteratorsBase _iteratorsBase;
        private readonly RepositoryBase _repositoryBase;
        private readonly ViewsBase _viewsBase;
        private SceneConfig _sceneConfig;

        public Scene(SceneConfig config)
        {
            _sceneConfig = config;
            _iteratorsBase = new IteratorsBase(config);
            _repositoryBase = new RepositoryBase(config);
            _viewsBase = new ViewsBase(config);
        }

        public Coroutine InitializeAsync()
        {
            return Coroutines.StartRoutine(InitializeRoutine());
        }

        private IEnumerator InitializeRoutine()
        {
            _iteratorsBase.CreateAllIterators();
            _repositoryBase.CreateAllRepositories();
            yield return null;

            _iteratorsBase.SendOnCreateToAllIterators();
            _repositoryBase.SendOnCreateToAllRepositories();
            yield return null;

            _iteratorsBase.InitializeAllIterators();
            _repositoryBase.InitializeAllRepositories();
            yield return null;

            _iteratorsBase.SendOnstartToAllIterators();
            _repositoryBase.SendOnstartToAllRepositories();
            yield return null;

            _viewsBase.CreateAllViews();
            yield return null;
            _viewsBase.SendOnCreateToAllViews();
            yield return null;
            _viewsBase.InitializeAllViews();
            yield return null;
            _viewsBase.SendOnstartToAllViews();
            yield return null;
        }

        public T GetRepository<T>() where T : Repository
        {
            return _repositoryBase.GetRepository<T>();
        }
        
        public T GetIterators<T>() where T : Iterator
        {
            return _iteratorsBase.GetIterator<T>();
        }
    }
}