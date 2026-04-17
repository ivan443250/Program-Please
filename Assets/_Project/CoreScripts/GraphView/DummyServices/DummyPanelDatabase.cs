using ElementaryCase;
using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "DummyPanelDatabase", menuName = "Installers/DummyPanelDatabase")]
public class DummyPanelDatabase : ScriptableObjectInstaller, IFunctionSpriteDatabase
{
    [SerializeField] private Sprite _default;

    public Sprite GetById(string id)
    {
        return _default;
    }

    public override void InstallBindings()
    {
        Container
            .Bind<IFunctionSpriteDatabase>()
            .FromInstance(this)
            .AsSingle();
    }
}