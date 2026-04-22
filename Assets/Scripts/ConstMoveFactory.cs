using UnityEngine;
using Assets.Scripts;

public class ConstMoveFactory : IMovedFactory<ConstSpeedMovedObject>
{
    public ConstSpeedMovedObject Create(MoveParams moveParams)
    {
        return new ConstSpeedMovedObject(moveParams);
    }
}

public class MoveParams
{
    public Vector2 startPos;
    public Vector2 direction;
    public float speed;

    public MoveParams(Vector2 startPos, Vector2 direction, float speed)
    {
        this.startPos = startPos;
        this.direction = direction;
        this.speed = speed;
    }
}
