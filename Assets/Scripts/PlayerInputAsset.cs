// GENERATED AUTOMATICALLY FROM 'Assets/PlayerInputAsset.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerInputAsset : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInputAsset()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInputAsset"",
    ""maps"": [
        {
            ""name"": ""Standing"",
            ""id"": ""44e6eb71-9a7f-4665-b230-0301b22fba13"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""39d06f77-c465-4fc9-9ef1-fd0ca22fc56f"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""054a84cd-931b-4fed-a9f4-856812d82ef5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Dash"",
                    ""type"": ""Button"",
                    ""id"": ""a1de51fe-d052-4960-8a70-2fb9cef11b2c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""cccafcf6-b1b5-48e0-99fa-9e75672ce971"",
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
                    ""id"": ""33654f04-8e4c-499f-994f-9ac9328d5c47"",
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
                    ""id"": ""fe856f0e-f12a-4826-957a-1c820e5ba345"",
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
                    ""id"": ""6de9fffc-2208-417c-914d-4bb5354db4ba"",
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
                    ""id"": ""376c405a-f251-4753-a8af-5313510938a9"",
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
                    ""id"": ""3aca6abd-a883-42fd-b146-aabddc136d1a"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3cff3940-b2f2-4971-b9fd-30abee8da4cd"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Standing
        m_Standing = asset.FindActionMap("Standing", throwIfNotFound: true);
        m_Standing_Movement = m_Standing.FindAction("Movement", throwIfNotFound: true);
        m_Standing_Jump = m_Standing.FindAction("Jump", throwIfNotFound: true);
        m_Standing_Dash = m_Standing.FindAction("Dash", throwIfNotFound: true);
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

    // Standing
    private readonly InputActionMap m_Standing;
    private IStandingActions m_StandingActionsCallbackInterface;
    private readonly InputAction m_Standing_Movement;
    private readonly InputAction m_Standing_Jump;
    private readonly InputAction m_Standing_Dash;
    public struct StandingActions
    {
        private @PlayerInputAsset m_Wrapper;
        public StandingActions(@PlayerInputAsset wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_Standing_Movement;
        public InputAction @Jump => m_Wrapper.m_Standing_Jump;
        public InputAction @Dash => m_Wrapper.m_Standing_Dash;
        public InputActionMap Get() { return m_Wrapper.m_Standing; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(StandingActions set) { return set.Get(); }
        public void SetCallbacks(IStandingActions instance)
        {
            if (m_Wrapper.m_StandingActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_StandingActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_StandingActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_StandingActionsCallbackInterface.OnMovement;
                @Jump.started -= m_Wrapper.m_StandingActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_StandingActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_StandingActionsCallbackInterface.OnJump;
                @Dash.started -= m_Wrapper.m_StandingActionsCallbackInterface.OnDash;
                @Dash.performed -= m_Wrapper.m_StandingActionsCallbackInterface.OnDash;
                @Dash.canceled -= m_Wrapper.m_StandingActionsCallbackInterface.OnDash;
            }
            m_Wrapper.m_StandingActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Dash.started += instance.OnDash;
                @Dash.performed += instance.OnDash;
                @Dash.canceled += instance.OnDash;
            }
        }
    }
    public StandingActions @Standing => new StandingActions(this);
    public interface IStandingActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnDash(InputAction.CallbackContext context);
    }
}
