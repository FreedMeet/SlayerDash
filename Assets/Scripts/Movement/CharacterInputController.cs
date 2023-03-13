using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Movement
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class CharacterInputController: MonoBehaviour
    {
        private IControllable _controllable;
        private GameInput _gameInput;
        private Camera _mainCamera;
        private Rigidbody2D _rb;

        private void Awake()
        {
            _mainCamera = Camera.main;
            _rb = GetComponent<Rigidbody2D>();
            _controllable = GetComponent<IControllable>();
            
            _gameInput = new GameInput();
            _gameInput.Enable();

            if (_controllable == null)
                throw new Exception($"there is no IControllable component on the object {gameObject.name}");
        }

        private void OnEnable()
        {
            _gameInput.Gameplay.Dash.performed += OnDashPerformed;
        }

        private void OnDashPerformed(InputAction.CallbackContext obj)
        {
            _controllable.Dash(_gameInput.Gameplay.Movement.ReadValue<Vector2>().normalized, _rb); 
        }

        private void OnDisable()
        {
            _gameInput.Gameplay.Dash.performed -= OnDashPerformed;
        }

        private void Update()
        {
            ReadMoveDirection();
            ReadGazeDirection(_mainCamera);
        }

        private void ReadMoveDirection()
        {
            var inputDirection = _gameInput.Gameplay.Movement.ReadValue<Vector2>();
            _controllable.Move(inputDirection.normalized, _rb);
        }

        private void ReadGazeDirection(Camera mainCamera)
        {
            var mousePosition = Mouse.current.position.ReadValue();
            var worldMousePosition = mainCamera.ScreenToWorldPoint(mousePosition);
            _controllable.Rotation(worldMousePosition, _rb);
        }
    }
}