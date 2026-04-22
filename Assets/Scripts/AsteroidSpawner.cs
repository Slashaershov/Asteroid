using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using Assets.Scripts;

public class AsteroidSpawner: IEnemySpawner
{
    private DiContainer _container;
    private ConstMoveFactory _constMoveFactory;

    private AsteroidPresentation _asteroidPresentation;

    public AsteroidSpawner(DiContainer container, ConstMoveFactory constMoveFactory, AsteroidPresentation asteroidPresentation)
    {
        _container = container;
        _constMoveFactory = constMoveFactory;
        _asteroidPresentation = asteroidPresentation;
    }

    public ObjectPresentation Spawn(MoveParams moveParams)
    {
        var move = _constMoveFactory.Create(moveParams);
        var asteroid = _container.InstantiatePrefabForComponent<AsteroidPresentation>(
            _asteroidPresentation,
            moveParams.startPos,
            Quaternion.identity,
            null
        );
        asteroid.SetMoved(move);
        return asteroid;
    }
}

public interface IMovedFactory<T> where T : IMoved
{
    T Create(MoveParams moveParams);
}

