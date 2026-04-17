using UnityEngine;
using Zenject;

namespace ElementaryCase
{
    public class SceneTestGraphViewEntryPoint : MonoBehaviour, IInitializable
    {
        private GraphView _graphView;

        [Inject]
        public void Construct(GraphView graphView)
        {
            _graphView = graphView;
        }

        public void Initialize()
        {
            _graphView.Initialize();
        }
    }
}