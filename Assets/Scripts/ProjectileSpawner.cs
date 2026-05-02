using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using Assets.Scripts;

public class ProjectileSpawner
{
    private DiContainer _container;
    private ConstMoveFactory _constMoveFactory;

    private ProjectilePresentation _presentation;

    public ProjectileSpawner(DiContainer container, ConstMoveFactory constMoveFactory, ProjectilePresentation presentation)
    {
        _container = container;
        _constMoveFactory = constMoveFactory;
        _presentation = presentation;
    }

    public ObjectPresentation Spawn(MoveParams moveParams)
    {
        var move = _constMoveFactory.Create(moveParams);
        var asteroid = _container.InstantiatePrefabForComponent<ProjectilePresentation>(
            _presentation,
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

