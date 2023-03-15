using System;
using System.Collections.Generic;
using Storage;
using Views;

namespace Scenes
{
    public abstract class SceneConfig
    {
        public abstract Dictionary<Type, Repository> CreateAllRepositories();
        public abstract Dictionary<Type, Iterator> CreateAllIterators();
        public abstract Dictionary<Type, View> CreateAllView();

        public abstract string sceneName { get; }

        public void CreateIterator<T>(Dictionary<Type, Iterator> iteratorsMap) where T : Iterator, new()
        {
            var iterator = new T();
            var type = typeof(T);

            iteratorsMap[type] = iterator;
        }
        
        public void CreateRepository<T>(Dictionary<Type, Repository> repositoriesMap) where T : Repository, new()
        {
            var repository = new T();
            var type = typeof(T);

            repositoriesMap[type] = repository;
        }

        public void CreateView<T>(Dictionary<Type, View> viewsMap) where T : View, new()
        {
            var view = new T();
            var type = typeof(T);

            viewsMap[type] = view;
        }
    }
}