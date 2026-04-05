using UnityEngine;
using Zenject;
using Assets.Scripts;

public class BaseInstaller : MonoInstaller
{

    public override void InstallBindings()
    {
        Container.Bind<ConstMoveFactory>().AsSingle();

        Container.Bind<AsteroidSpawner>()
                 .AsSingle()
                 .OnInstantiated<AsteroidSpawner>(null);

       // Container.Bind<GameSpawner>().FromComponentInHierarchy().AsSingle();
    }
}
