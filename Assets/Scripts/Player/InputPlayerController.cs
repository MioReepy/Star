using UnityEngine;
using UnityEngine.InputSystem;

namespace PlayerSpace
{
    public class InputPlayerController : MonoBehaviour
    {
        private PlayerInput _playerInput;
        private InputAction _actionMove;

        private void Awake()
        {
            _playerInput = GetComponent<PlayerInput>();
            _actionMove = _playerInput.actions["Move"];
        }

        private void Update()
        {
            Move();
        }

        private void Move()
        {
            Vector2 input = _actionMove.ReadValue<Vector2>();
            Player.SingletonPlayer.Move(input);
        }
    }
}