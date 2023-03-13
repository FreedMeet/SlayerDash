using System;
using System.Collections.Generic;
using Storage;
using Storage.Dash;
using Storage.Player;

namespace Scenes
{
    public class SceneConfigMain : SceneConfig
    {
        public const string SceneName = "SampleScene";
        public override string sceneName => SceneName;
        
        public override Dictionary<Type, Repository> CreateAllRepositories()
        {
            var repositoriesMap = new Dictionary<Type, Repository>();
            
            CreateRepository<DashRepository>(repositoriesMap);
            CreateRepository<PlayerRepository>(repositoriesMap);

            return repositoriesMap;
        }

        public override Dictionary<Type, Iterator> CreateAllIterators()
        {
            var iteratorsMap = new Dictionary<Type, Iterator>();
            
            CreateIterator<DashIterator>(iteratorsMap);
            CreateIterator<PlayerIterator>(iteratorsMap);
            
            return iteratorsMap;
        }
    }
}