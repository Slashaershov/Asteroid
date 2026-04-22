using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;

public class FlyTapeMoved : MovedObject
{
    private MovedObject _target;
    public FlyTapeMoved(MoveParams moveParams, MovedObject target) : base(moveParams)
    {
        _target = target;
    }

    protected override Vector2 CalcSpeed(float duration)
    {
        return (_target.GetPosition() - GetPosition()).normalized * baseSpeed;
    }
}
