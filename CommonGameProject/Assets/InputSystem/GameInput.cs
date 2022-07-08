//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.3.0
//     from Assets/InputSystem/GameInput.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace InputPresets
{
    public partial class @GameInput : IInputActionCollection2, IDisposable
    {
        public InputActionAsset asset { get; }
        public @GameInput()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""GameInput"",
    ""maps"": [
        {
            ""name"": ""InGameMobile"",
            ""id"": ""0fe34d2d-082b-4b15-bc93-c2237d6b1a29"",
            ""actions"": [
                {
                    ""name"": ""New action"",
                    ""type"": ""Button"",
                    ""id"": ""96297f86-fac8-47e2-9393-26fd6ec3bbc3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""58ed52a4-2547-4467-97c8-c2a17882284d"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""New action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""InGameEditor"",
            ""id"": ""c71f3092-6f2d-4949-a6bd-029f10a4db24"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""a86de3fe-8270-4741-981b-db4df17a1c71"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""MouseClick"",
                    ""type"": ""Button"",
                    ""id"": ""3339f17d-4799-4e71-8004-c67e30249d83"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""932bfb3c-c77f-4811-a8d4-3d54bfc913f4"",
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
                    ""id"": ""21520edc-6472-49bc-bde2-eac2af22493d"",
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
                    ""id"": ""0110a0e0-af0c-4fc7-9727-0b55672a7aea"",
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
                    ""id"": ""cd9b7f32-8b20-42fc-a99b-887139f423a6"",
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
                    ""id"": ""f2acfd69-fbc4-4b67-9ed2-20c72053a23c"",
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
                    ""id"": ""0888d24e-a558-430e-9799-fe1d6ac403c4"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MouseClick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
            // InGameMobile
            m_InGameMobile = asset.FindActionMap("InGameMobile", throwIfNotFound: true);
            m_InGameMobile_Newaction = m_InGameMobile.FindAction("New action", throwIfNotFound: true);
            // InGameEditor
            m_InGameEditor = asset.FindActionMap("InGameEditor", throwIfNotFound: true);
            m_InGameEditor_Movement = m_InGameEditor.FindAction("Movement", throwIfNotFound: true);
            m_InGameEditor_MouseClick = m_InGameEditor.FindAction("MouseClick", throwIfNotFound: true);
        }

        public void Dispose()
        {
            UnityEngine.Object.Destroy(asset);
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
        public IEnumerable<InputBinding> bindings => asset.bindings;

        public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
        {
            return asset.FindAction(actionNameOrId, throwIfNotFound);
        }
        public int FindBinding(InputBinding bindingMask, out InputAction action)
        {
            return asset.FindBinding(bindingMask, out action);
        }

        // InGameMobile
        private readonly InputActionMap m_InGameMobile;
        private IInGameMobileActions m_InGameMobileActionsCallbackInterface;
        private readonly InputAction m_InGameMobile_Newaction;
        public struct InGameMobileActions
        {
            private @GameInput m_Wrapper;
            public InGameMobileActions(@GameInput wrapper) { m_Wrapper = wrapper; }
            public InputAction @Newaction => m_Wrapper.m_InGameMobile_Newaction;
            public InputActionMap Get() { return m_Wrapper.m_InGameMobile; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(InGameMobileActions set) { return set.Get(); }
            public void SetCallbacks(IInGameMobileActions instance)
            {
                if (m_Wrapper.m_InGameMobileActionsCallbackInterface != null)
                {
                    @Newaction.started -= m_Wrapper.m_InGameMobileActionsCallbackInterface.OnNewaction;
                    @Newaction.performed -= m_Wrapper.m_InGameMobileActionsCallbackInterface.OnNewaction;
                    @Newaction.canceled -= m_Wrapper.m_InGameMobileActionsCallbackInterface.OnNewaction;
                }
                m_Wrapper.m_InGameMobileActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Newaction.started += instance.OnNewaction;
                    @Newaction.performed += instance.OnNewaction;
                    @Newaction.canceled += instance.OnNewaction;
                }
            }
        }
        public InGameMobileActions @InGameMobile => new InGameMobileActions(this);

        // InGameEditor
        private readonly InputActionMap m_InGameEditor;
        private IInGameEditorActions m_InGameEditorActionsCallbackInterface;
        private readonly InputAction m_InGameEditor_Movement;
        private readonly InputAction m_InGameEditor_MouseClick;
        public struct InGameEditorActions
        {
            private @GameInput m_Wrapper;
            public InGameEditorActions(@GameInput wrapper) { m_Wrapper = wrapper; }
            public InputAction @Movement => m_Wrapper.m_InGameEditor_Movement;
            public InputAction @MouseClick => m_Wrapper.m_InGameEditor_MouseClick;
            public InputActionMap Get() { return m_Wrapper.m_InGameEditor; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(InGameEditorActions set) { return set.Get(); }
            public void SetCallbacks(IInGameEditorActions instance)
            {
                if (m_Wrapper.m_InGameEditorActionsCallbackInterface != null)
                {
                    @Movement.started -= m_Wrapper.m_InGameEditorActionsCallbackInterface.OnMovement;
                    @Movement.performed -= m_Wrapper.m_InGameEditorActionsCallbackInterface.OnMovement;
                    @Movement.canceled -= m_Wrapper.m_InGameEditorActionsCallbackInterface.OnMovement;
                    @MouseClick.started -= m_Wrapper.m_InGameEditorActionsCallbackInterface.OnMouseClick;
                    @MouseClick.performed -= m_Wrapper.m_InGameEditorActionsCallbackInterface.OnMouseClick;
                    @MouseClick.canceled -= m_Wrapper.m_InGameEditorActionsCallbackInterface.OnMouseClick;
                }
                m_Wrapper.m_InGameEditorActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Movement.started += instance.OnMovement;
                    @Movement.performed += instance.OnMovement;
                    @Movement.canceled += instance.OnMovement;
                    @MouseClick.started += instance.OnMouseClick;
                    @MouseClick.performed += instance.OnMouseClick;
                    @MouseClick.canceled += instance.OnMouseClick;
                }
            }
        }
        public InGameEditorActions @InGameEditor => new InGameEditorActions(this);
        public interface IInGameMobileActions
        {
            void OnNewaction(InputAction.CallbackContext context);
        }
        public interface IInGameEditorActions
        {
            void OnMovement(InputAction.CallbackContext context);
            void OnMouseClick(InputAction.CallbackContext context);
        }
    }
}
