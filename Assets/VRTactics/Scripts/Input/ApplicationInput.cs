// GENERATED AUTOMATICALLY FROM 'Assets/SberTestProject/Settings/Input/ApplicationInput.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;
using Object = UnityEngine.Object;

namespace VRTactics.Input
{
    public class ApplicationInput : IInputActionCollection, IDisposable
    {
        // Player
        private readonly InputActionMap m_Player;
        private readonly InputAction m_Player_Look;
        private readonly InputAction m_Player_Movement;
        private IPlayerActions m_PlayerActionsCallbackInterface;

        public ApplicationInput()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""ApplicationInput"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""7c781b4e-c2bd-49d5-997a-5109bcebb428"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Button"",
                    ""id"": ""f0a24555-933d-4181-9d3e-e82ca2fd9ddd"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Look"",
                    ""type"": ""PassThrough"",
                    ""id"": ""49ccedd6-1b97-452e-ad47-daf3916b8746"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""d39dae75-5a9b-4563-9064-c49aa9841673"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""bab2a97f-d90f-49b9-9b51-fae8baab9363"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""aa0d0050-f9e8-4139-a3c6-367af2862a53"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""e4f4a4ff-e4dd-4da3-94b9-86daa698310e"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""de959089-d858-4281-99fb-4d1377550aaa"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""5a5df799-1fad-46d7-a3bc-c65067d943de"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
            // Player
            m_Player = asset.FindActionMap("Player", true);
            m_Player_Movement = m_Player.FindAction("Movement", true);
            m_Player_Look = m_Player.FindAction("Look", true);
        }

        public InputActionAsset asset { get; }
        public PlayerActions Player => new PlayerActions(this);

        public void Dispose()
        {
            Object.Destroy(asset);
        }

        public InputBinding? bindingMask
        {
            get => asset.bindingMask;
            set => asset.bindingMask = value;
        }

        public ReadOnlyArray<InputDevice>? devices
        {
            get => asset.devices;
            set => asset.devices = value;
        }

        public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

        public bool Contains(InputAction action)
        {
            return asset.Contains(action);
        }

        public IEnumerator<InputAction> GetEnumerator()
        {
            return asset.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Enable()
        {
            asset.Enable();
        }

        public void Disable()
        {
            asset.Disable();
        }

        public struct PlayerActions
        {
            private readonly ApplicationInput m_Wrapper;

            public PlayerActions(ApplicationInput wrapper)
            {
                m_Wrapper = wrapper;
            }

            public InputAction Movement => m_Wrapper.m_Player_Movement;
            public InputAction Look => m_Wrapper.m_Player_Look;

            public InputActionMap Get()
            {
                return m_Wrapper.m_Player;
            }

            public void Enable()
            {
                Get().Enable();
            }

            public void Disable()
            {
                Get().Disable();
            }

            public bool enabled => Get().enabled;

            public static implicit operator InputActionMap(PlayerActions set)
            {
                return set.Get();
            }

            public void SetCallbacks(IPlayerActions instance)
            {
                if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
                {
                    Movement.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                    Movement.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                    Movement.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                    Look.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLook;
                    Look.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLook;
                    Look.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLook;
                }

                m_Wrapper.m_PlayerActionsCallbackInterface = instance;
                if (instance != null)
                {
                    Movement.started += instance.OnMovement;
                    Movement.performed += instance.OnMovement;
                    Movement.canceled += instance.OnMovement;
                    Look.started += instance.OnLook;
                    Look.performed += instance.OnLook;
                    Look.canceled += instance.OnLook;
                }
            }
        }

        public interface IPlayerActions
        {
            void OnMovement(InputAction.CallbackContext context);
            void OnLook(InputAction.CallbackContext context);
        }
    }
}