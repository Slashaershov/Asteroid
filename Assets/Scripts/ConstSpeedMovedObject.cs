using System.Collections;
using UnityEngine;
using System;

namespace Assets.Scripts
{
    public class ConstSpeedMovedObject : MovedObject
    {
        private Vector2 _currentSpeed;
        public ConstSpeedMovedObject(MoveParams moveParams) : base(moveParams)
        {
            _currentSpeed = moveParams.direction.normalized * baseSpeed;
        }

        protected override Vector2 CalcSpeed(float duration)
        {
            return _currentSpeed;
        }
    }
}