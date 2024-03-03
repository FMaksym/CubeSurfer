using UnityEngine;
using Zenject;

public class PlayerInstaller : MonoInstaller
{
    [SerializeField] private Player _player;
    [SerializeField] private StackOfTowerCubes _stackOfTowerCubes;

    public override void InstallBindings()
    {
        Container.Bind<Player>().FromInstance(_player).AsSingle();
        Container.Bind<StackOfTowerCubes>().FromInstance(_stackOfTowerCubes).AsSingle();
    }
}