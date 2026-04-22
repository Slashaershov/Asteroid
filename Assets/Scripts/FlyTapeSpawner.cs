using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using Assets.Scripts;

public class FlyTapeSpawner: IEnemySpawner
{
    private DiContainer _container;
    private FlyTapeMoveFactory _factory;

    private FlyTapePresentation _flyTapePresentation;

    public FlyTapeSpawner(DiContainer container, FlyTapeMoveFactory factory, FlyTapePresentation flyTapePresentation)
    {
        _container = container;
        _factory = factory;
        _flyTapePresentation = flyTapePresentation;
    }

    public ObjectPresentation Spawn(MoveParams moveParams)
    {
        var move = _factory.Create(moveParams.startPos);
        var res = _container.InstantiatePrefabForComponent<FlyTapePresentation>(
            _flyTapePresentation,
            moveParams.startPos,
            Quaternion.identity,
            null
        );
        res.SetMoved(move);
        return res;
    }
}

public interface IEnemySpawner
{
    public ObjectPresentation Spawn(MoveParams moveParams);
}
