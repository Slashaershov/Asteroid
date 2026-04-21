using UnityEngine;
using Zenject;
using Assets.Scripts;

public class BaseInstaller : MonoInstaller
{
    public PlayerPresentation playerPrefab;
    public AsteroidPresentation _asteroidPresentation;
    public override void InstallBindings()
    {
        BindPlayer();
        BindAstro();
    }

    private void BindPlayer()
    {
        var conf = new PlayerConfig();
        var pl = new PlayerMoved(conf);
        Container.Bind<PlayerMoved>().FromInstance(pl).AsSingle();
        Container.Bind<IMoved>().FromInstance(pl).WhenInjectedInto<PlayerPresentation>();
    }

    private void BindAstro()
    {
        Container.Bind<ConstMoveFactory>().AsSingle();
        Container.Bind<AsteroidPresentation>().FromInstance(_asteroidPresentation);
        Container.Bind<AsteroidSpawner>().AsSingle();
        //Container.Bind<AsteroidSpawner>()
        //         .AsSingle()
        //         .OnInstantiated<AsteroidSpawner>(null);
    }

}

public class PlayerConfig
{
    public float _accelerationMultiplier = 1;
    public float _maxSpeed = 5;
    public Vector2 _startSpeed = Vector2.zero;
}
