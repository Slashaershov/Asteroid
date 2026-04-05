using System.Collections;
using UnityEngine;
using Zenject;
namespace Assets.Scripts
{
    public class ObjectPresentation : MonoBehaviour
    {

        private IMoved _moved;

        public void Update()
        {
            UpdatePosition();
        }

        public void SetMoved(IMoved moved)
        {
            _moved = moved;
        }

        protected void UpdatePosition()
        {
            _moved.UpdateMovement(Time.deltaTime);
            transform.position = _moved.GetPosition();
        }
    }
}