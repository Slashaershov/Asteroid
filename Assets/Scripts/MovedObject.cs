using System.Collections;
using UnityEngine;
using System;

namespace Assets.Scripts
{
    public abstract class MovedObject : IMoved
    {
        protected const float BASE_MOVE_SPEED = 1;
        protected float baseSpeed;
        protected Vector2 position;
        private Action OnMove;
        public Vector2 GetPosition() => position;

        public MovedObject(MoveParams moveParam)
        {
            this.baseSpeed = moveParam.speed;
            position = moveParam.startPos;
        }

        public void UpdateMovement(float duration)
        {
            var speed = CalcSpeed(duration);
            UpdatePosition(speed, duration);
        }

        public void SetAction(Action onMove)
        {
            OnMove += onMove;
        }

        public void SetPosition(Vector2 pos)
        {
            position = pos;
        }

        protected abstract Vector2 CalcSpeed(float duration);

        protected void UpdatePosition(Vector2 speed, float duration)
        {
            position += speed * duration;
            OnMove?.Invoke();
        }
    }
}