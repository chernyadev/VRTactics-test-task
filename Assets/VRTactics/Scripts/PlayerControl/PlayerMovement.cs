using UnityEngine;

namespace VRTactics.PlayerControl
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerMovement : PlayerInputHandler
    {
        private const float DEFAULT_VERTICAL_SPEED = -2.0f;
        [Header("Movement")]
        [SerializeField]
        private float movementSpeed = 4.0f;

        [Header("Gravity")]
        [SerializeField]
        private float gravity = -9.81f;
        [SerializeField]
        private LayerMask groundLayerMask;
        [SerializeField]
        private Transform groundCheckRoot;
        [SerializeField]
        private float groundCheckRadius = 0.1f;
        private CharacterController _characterController;
        private Vector2 _movementInput = Vector2.zero;

        private Transform _playerTransform;
        private float _verticalSpeed;

        private void Awake()
        {
            _playerTransform = transform;
            _characterController = GetComponent<CharacterController>();
        }

        private void Update()
        {
            Move();
        }

        private void OnEnable()
        {
            inputProvider.MovementEvent += MoveInputHandler;
        }

        private void OnDisable()
        {
            inputProvider.MovementEvent -= MoveInputHandler;
        }

        private void Move()
        {
            _verticalSpeed = IsGrounded() ? DEFAULT_VERTICAL_SPEED : _verticalSpeed + gravity * Time.deltaTime;
            var verticalSpeed = Vector3.up * _verticalSpeed;

            var horizontalMovement = new Vector3(_movementInput.x, 0, _movementInput.y);
            var horizontalSpeed = _playerTransform.rotation * horizontalMovement * movementSpeed;
            _characterController.Move((verticalSpeed + horizontalSpeed) * Time.deltaTime);
        }

        private void MoveInputHandler(Vector2 movement)
        {
            _movementInput = movement.normalized;
        }

        private bool IsGrounded()
        {
            return Physics.CheckSphere(groundCheckRoot.position, groundCheckRadius, groundLayerMask);
        }
    }
}