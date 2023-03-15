using System;
using System.Collections.Generic;
using Scenes;

namespace Views
{
    public class ViewsBase
    {
        private Dictionary<Type, View> _viewsMap;
        private SceneConfig _sceneConfig;

        public ViewsBase(SceneConfig sceneConfig)
        {
            _sceneConfig = sceneConfig;
        }

        public void CreateAllViews()
        {
            _viewsMap = _sceneConfig.CreateAllView();
        }
        
        public void SendOnCreateToAllViews()
        {
            var allViews = _viewsMap.Values;
            foreach (var view in allViews)
            {
                view.OnCreate();
            }
        }
        
        public void InitializeAllViews()
        {
            var allViews = _viewsMap.Values;
            foreach (var view in allViews)
            {
                view.Initialize();
            }
        }
        
        public void SendOnstartToAllViews()
        {
            var allViews = _viewsMap.Values;
            foreach (var view in allViews)
            {
                view.OnStart();
            }
        }

        public T GetView<T>() where T : View
        {
            var type = typeof(T);
            return (T)_viewsMap[type];
        }
    }
}