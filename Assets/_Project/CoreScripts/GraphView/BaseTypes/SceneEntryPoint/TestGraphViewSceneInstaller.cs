using Zenject;

namespace ElementaryCase
{
    public class TestGraphViewSceneInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container
                .Bind(typeof(SceneTestGraphViewEntryPoint), typeof(IInitializable))
                .FromComponentInHierarchy()
                .AsSingle();

            Container
                .Bind<GraphView>()
                .FromComponentInHierarchy()
                .AsSingle();
        }
    }
}