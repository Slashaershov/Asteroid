using System.Collections;
using UnityEngine;
using System;

namespace Assets.Scripts
{
    public class ConstSpeedMovedObject : MovedObject
    {
        private Vector2 _currentSpeed;
        public ConstSpeedMovedObject(Vector2 startPos, Vector2 direction, float baseSpeed) : base(startPos, baseSpeed)
        {
            _currentSpeed = direction.normalized * baseSpeed;
        }

        protected override Vector2 CalcSpeed(float duration)
        {
            return _currentSpeed;
        }
    }
}