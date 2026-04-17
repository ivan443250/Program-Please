using UnityEngine;
using Zenject;

namespace ElementaryCase
{
    public class GraphView : MonoBehaviour
    {
        public void Initialize()
        {
            GetComponentInChildren<GameObjectContext>().Run();
        }
    }
}