using UnityEngine;

namespace VRTactics.PlayerControl
{
    public class PlayerLook : PlayerInputHandler
    {
        [SerializeField]
        private Transform _cameraTransform;

        [Space]
        [SerializeField]
        private Vector2 sensitivity = new Vector2(10, 4);
        [SerializeField]
        private Vector2 verticalRotationLimits = new Vector2(-80, 60);
        [SerializeField]
        private bool invertY = true;

        private Vector2 _lookInput = Vector2.zero;

        private Transform _playerTransform;
        private Vector2 _rotation = Vector2.zero;

        private void Awake()
        {
            _playerTransform = transform;
        }

        private void Update()
        {
            _rotation += Vector2.Scale(_lookInput, sensitivity) * Time.deltaTime;
            _rotation.y = Mathf.Clamp(_rotation.y, verticalRotationLimits.x, verticalRotationLimits.y);

            _playerTransform.localRotation = Quaternion.Euler(0, _rotation.x, 0);
            _cameraTransform.localRotation = Quaternion.Euler(_rotation.y, 0, 0);
        }

        private void OnEnable()
        {
            inputProvider.LookEvent += LookInputHandler;
        }

        private void OnDisable()
        {
            inputProvider.LookEvent -= LookInputHandler;
        }

        private void LookInputHandler(Vector2 lookInput)
        {
            _lookInput = lookInput;
            if (invertY)
            {
                _lookInput.y *= -1;
            }
        }
    }
}