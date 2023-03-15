namespace Scenes
{
    public class SceneManagerMain : SceneManagerBase
    {
        public override void InitScenesMap()
        {
            _sceneConfigMap[SceneConfigMain.SceneName] = new SceneConfigMain();
        }
    }
}