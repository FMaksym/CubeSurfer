using UnityEngine;
using Zenject;

public class ManagersInstaller : MonoInstaller
{
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private RoadManager _roadManager;

    public override void InstallBindings()
    {
        Container.Bind<GameManager>().FromInstance(_gameManager).AsSingle();
        Container.Bind<RoadManager>().FromInstance(_roadManager).AsSingle();
    }
}