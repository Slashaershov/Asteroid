using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;
using Zenject;

public class FlyTapeMoveFactory
{
    private readonly MovedObject _playerTarget;

    [Inject]
    public FlyTapeMoveFactory(MovedObject playerTarget)
    {
        _playerTarget = playerTarget;
    }

    public FlyTapeMoved Create(Vector2 startPos)
    {
        return new FlyTapeMoved(new MoveParams(startPos, Vector2.zero, 1f), _playerTarget);
    }
}
