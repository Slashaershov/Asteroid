using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Assets.Scripts
{
    public class PlayerMoved : MovedObject
    {
        private Vector2 _currentSpeed;
        private float _maxSpeedSqr;
        private float _maxSpeed;
        private float _accelerationMultiplier;
        private Vector2 _direction;

        public PlayerMoved(PlayerConfig config) : base(Vector2.zero, BASE_MOVE_SPEED)
        {
            _accelerationMultiplier = config._accelerationMultiplier;
            _maxSpeed = config._maxSpeed;
            _maxSpeedSqr = _maxSpeed * _maxSpeed;
        }

        public void UpdateMovement(Vector2 direction, float duration)
        {
            _direction = direction;
            UpdateMovement(duration);
        }

        protected override Vector2 CalcSpeed(float duration)
        {
            var acceleration = _direction * _maxSpeed - _currentSpeed;
            var newSpeed = acceleration * duration * _accelerationMultiplier + _currentSpeed;
            if (newSpeed.sqrMagnitude > _maxSpeedSqr)
            {
                newSpeed.Normalize();
                newSpeed *= _maxSpeed;
            }
            _currentSpeed = newSpeed;
            return _currentSpeed;
        }
    }

    //public class PlayerConfig()
}