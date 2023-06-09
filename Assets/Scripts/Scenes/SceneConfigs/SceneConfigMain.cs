﻿using System;
using System.Collections.Generic;
using Storage;
using Storage.Dash;
using Storage.Player;
using Storage.Room;
using Storage.Shooting;
using Views;
using Views.MapView;
using Views.PlayerView;

namespace Scenes.SceneConfigs
{
    public class SceneConfigMain : SceneConfig
    {
        public const string SceneName = "SampleScene";

        public override string sceneName => SceneName;
        
        public override Dictionary<Type, Repository> CreateAllRepositories()
        {
            var repositoriesMap = new Dictionary<Type, Repository>();
            
            CreateRepository<RoomRepository>(repositoriesMap);
            CreateRepository<DashRepository>(repositoriesMap);
            CreateRepository<PlayerRepository>(repositoriesMap);
            CreateRepository<ShootingRepository>(repositoriesMap);

            return repositoriesMap;
        }

        public override Dictionary<Type, Iterator> CreateAllIterators()
        {
            var iteratorsMap = new Dictionary<Type, Iterator>();
            
            CreateIterator<RoomIterator>(iteratorsMap);
            CreateIterator<DashIterator>(iteratorsMap);
            CreateIterator<PlayerIterator>(iteratorsMap);
            CreateIterator<ShootingIterator>(iteratorsMap);

            return iteratorsMap;
        }
        
        public override Dictionary<Type, View> CreateAllView()
        {
            var viewsMap = new Dictionary<Type, View>();
            
            CreateView<DashView>(viewsMap);
            CreateView<ShootView>(viewsMap);
            CreateView<MapView>(viewsMap);

            return viewsMap;
        }
    }
}