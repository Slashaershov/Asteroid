using UnityEngine;
using Zenject;
using Assets.Scripts;

public class BaseInstaller : MonoInstaller
{
    public PlayerPresentation playerPrefab;
    public AsteroidPresentation asteroidPrefab;
    public ProjectilePresentation projectilePrefab;
    public FlyTapePresentation flyTapePrefab;


    public float _laserReloadTime = 2f;

    private PlayerMoved _playerMoved;



    public override void InstallBindings()
    {
        BindPlayer();
        BindAstro();
        BindFlyTape();
        BindProjctile();
        BindLaser();
        BindSomething();
    }

    private void BindSomething()
    {

    }

    private void BindPlayer()
    {
        var conf = new PlayerConfig();
        _playerMoved = new PlayerMoved(conf);

        Container.Bind<PlayerMoved>().FromInstance(_playerMoved).AsSingle();
        Container.Bind<IMoved>().FromInstance(_playerMoved).WhenInjectedInto<PlayerPresentation>();
        Container.Bind<MovedObject>().FromInstance(_playerMoved).AsSingle();
        Container.Bind<ShootingComponent>().AsSingle();
    }

    private void BindAstro()
    {
        Container.Bind<ConstMoveFactory>().AsSingle();
        Container.BindInstance(asteroidPrefab).WhenInjectedInto<AsteroidSpawner>();
        Container.Bind<AsteroidSpawner>().AsSingle();
    }    
    
    private void BindProjctile()
    {
        Container.BindInstance(projectilePrefab);
        Container.BindInstance(projectilePrefab).WhenInjectedInto<ProjectilePresentation>();
        Container.Bind<ProjectileSpawner>().AsSingle();
    }

    private void BindFlyTape()
    {
        Container.Bind<FlyTapeMoveFactory>().AsSingle();
        Container.BindInstance(flyTapePrefab).WhenInjectedInto<FlyTapeSpawner>();
        Container.Bind<FlyTapeSpawner>().AsSingle();
    }

    private void BindLaser()
    {
        Container.Bind<LaserActivator>()
            .AsSingle()
            .WithArguments(_laserReloadTime);
    }
}

public class PlayerConfig
{
    public float _accelerationMultiplier = 1;
    public float _maxSpeed = 5;
    public Vector2 _startSpeed = Vector2.zero;
}
