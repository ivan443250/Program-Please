using Zenject;

namespace ElementaryCase.Test
{
    public class TestSceneInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container
                .Bind(typeof(RuntimeConsoleLibrary), typeof(ILibrary))
                .FromComponentInHierarchy()
                .AsSingle();

            Container
               .Bind<TextEditor>()
               .FromComponentInHierarchy()
               .AsSingle();

            Container
                .Bind<IInitializable>()
                .To<SceneEntryPoint>()
                .AsSingle();
        }
    }
}