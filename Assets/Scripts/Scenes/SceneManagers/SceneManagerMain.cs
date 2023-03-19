using Scenes.SceneConfigs;

namespace Scenes.SceneManagers
{
    public class SceneManagerMain : SceneManagerBase
    {
        public override void InitScenesMap()
        {
            _sceneConfigMap[SceneConfigMain.SceneName] = new SceneConfigMain();
        }
    }
}