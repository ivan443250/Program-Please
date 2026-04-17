using UnityEngine;
using Zenject;

namespace ElementaryCase
{
    public class StateMachineInstaller : MonoInstaller
    {
        [SerializeField] private FunctionsMenu.Options _functionsMenuOptions;

        public override void InstallBindings()
        {
            Container
                .Bind(typeof(GraphViewStateMachine), typeof(IInitializable))
                .FromComponentInHierarchy()
                .AsSingle();

            Container
                .Bind<FunctionsMenu.Options>()
                .FromInstance(_functionsMenuOptions)
                .AsSingle()
                .WhenInjectedInto<FunctionsMenu>();
            Container
                .Bind<FunctionsMenu>()
                .FromComponentInHierarchy()
                .AsSingle();
        }
    }
}