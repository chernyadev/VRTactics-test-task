using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace VRTactics.Input
{
    [CreateAssetMenu(menuName = "SO/Input Provider", fileName = "ApplicationInputProvider")]
    public class ApplicationInputProvider : ScriptableObject, ApplicationInput.IPlayerActions
    {
        private ApplicationInput _applicationInput;

        private void OnEnable()
        {
            EnableInput();
        }

        private void OnDisable()
        {
            DisableInput();
        }

        public void OnMovement(InputAction.CallbackContext context)
        {
            MovementEvent?.Invoke(context.ReadValue<Vector2>());
        }

        public void OnLook(InputAction.CallbackContext context)
        {
            LookEvent?.Invoke(context.ReadValue<Vector2>());
        }

        public event UnityAction<Vector2> MovementEvent;
        public event UnityAction<Vector2> LookEvent;

        public void EnableInput()
        {
            if (_applicationInput is null)
            {
                _applicationInput = new ApplicationInput();
                _applicationInput.Player.SetCallbacks(this);
            }

            _applicationInput.Player.Enable();
        }

        public void DisableInput()
        {
            _applicationInput.Player.Disable();
        }
    }
}