using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Assets.Scripts
{
    public class InputSystem : MonoBehaviour
    {
        private PlayerMoved _player;
        private ShootingComponent _shooter;
        [SerializeField] private float _maxSpeed = 3f;
        [SerializeField] private float _accelerationMultiplier = 1f;

        private const KeyCode _upKey = KeyCode.W;
        private const KeyCode _downKey = KeyCode.S;
        private const KeyCode _leftKey = KeyCode.A;
        private const KeyCode _rightKey = KeyCode.D;
        private const KeyCode _shootKey = KeyCode.R;


        [Inject]
        public void Construct(PlayerMoved moved, ShootingComponent shooter)
        {
            Debug.LogError("Constract 1");
            _player = moved; // new PlayerMoved(Vector2.zero, _maxSpeed, _accelerationMultiplier);
            Debug.LogError("Constract");
            _shooter = shooter;
        }

        public void Update()
        {
            InputProcess();
        }

        public void InputProcess()
        {
            UpdateMoving();
            UpdateShoot();
        }

        private void UpdateMoving()
        {
            var moveInput = Vector2.zero;

            if (Input.GetKey(_upKey)) moveInput.y = 1;
            if (Input.GetKey(_downKey)) moveInput.y = -1;
            if (Input.GetKey(_leftKey)) moveInput.x = -1;
            if (Input.GetKey(_rightKey)) moveInput.x = 1;
            _player.UpdateMovement(moveInput, Time.deltaTime);
        }

        private void UpdateShoot()
        {
            _shooter.Shoot();
        }
    }
}
