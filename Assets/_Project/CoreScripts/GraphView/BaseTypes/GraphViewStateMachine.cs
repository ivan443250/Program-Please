using UnityEngine;
using Zenject;

namespace ElementaryCase
{
    public class GraphViewStateMachine : MonoBehaviour, IInitializable
    {
        private FunctionsMenu _functionsMenu;

        [Inject]
        public void Construct(FunctionsMenu functionsMenu)
        {
            _functionsMenu = functionsMenu;
        }

        public void Initialize()
        {
            _functionsMenu.Initialize();
        }
    }
}
