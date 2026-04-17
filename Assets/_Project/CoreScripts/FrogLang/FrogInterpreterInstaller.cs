using Zenject;

namespace ElementaryCase
{
    public class FrogInterpreterInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container
                .Bind<IInterpreter>()
                .To<FrogLangInterpreter>()
                .AsSingle();

            Container
                .Bind(typeof(IFunctionModulesCollection), typeof(IFunctionModulesImporter))
                .To<FunctionModulesController>()
                .AsSingle();

            Container
                .Bind<IRuntimeVariableCollection>()
                .To<RuntimeVariableCollection>()
                .AsSingle();

            Container
                .Bind<ILibrary>()
                .To<FrogLangCoreLibrary>()
                .AsSingle();
        }
    }
}
