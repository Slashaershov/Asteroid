using System.Collections;
using UnityEngine;
using System;

namespace Assets.Scripts
{
    public abstract class MovedObject : IMoved
    {
        protected const float BASE_MOVE_SPEED = 0;
        protected float baseSpeed;
        protected Vector2 position;
        public Vector2 GetPosition() => position;

        public MovedObject(Vector2 startPos, float baseSpeed)
        {
            this.baseSpeed = baseSpeed;
            position = startPos;
        }

        public void UpdateMovement(float duration)
        {
            var speed = CalcSpeed(duration);
            UpdatePosition(speed, duration);
        }

        protected abstract Vector2 CalcSpeed(float duration);

        protected void UpdatePosition(Vector2 speed, float duration)
        {
            position += speed * duration;
        }
    }
}