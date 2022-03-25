//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.3.0
//     from Assets/Scripts/PlayerCont.inputactions
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

public partial class @PlayerCont : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerCont()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerCont"",
    ""maps"": [
        {
            ""name"": ""Gameplay"",
            ""id"": ""730512f1-6613-414e-98eb-f3cff6ceb333"",
            ""actions"": [
                {
                    ""name"": ""Horizontal"",
                    ""type"": ""Value"",
                    ""id"": ""79f9f9c6-c607-48ed-8bf8-325ebcc392c4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""bba91f32-904a-4b1b-9cc7-f797c2ed537b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Dash"",
                    ""type"": ""Button"",
                    ""id"": ""5ef1bae4-86e0-4822-904f-3f160e254ff0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Physical"",
                    ""type"": ""Button"",
                    ""id"": ""bba7a5b0-aed2-4f86-8930-41218cc7cf48"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Magical"",
                    ""type"": ""Button"",
                    ""id"": ""49ddd374-d317-4193-8b66-09cef0361d07"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Swap"",
                    ""type"": ""Button"",
                    ""id"": ""bd1d59d4-5f64-4944-b915-622df39233ea"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Counter"",
                    ""type"": ""Button"",
                    ""id"": ""8f7b083c-d1e7-4956-a1dd-05a19387cbff"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Up"",
                    ""type"": ""Button"",
                    ""id"": ""c8f0c5ca-f9e2-4a3e-9dd5-7c5320496887"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Down"",
                    ""type"": ""Button"",
                    ""id"": ""daa391e8-b78e-483b-9bf1-941cd27ffdbe"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""XAxis"",
                    ""id"": ""b0bb4316-249f-4d3e-b636-37cf54079d70"",
                    ""path"": ""1DAxis"",
                    ""interactions"": ""Hold(duration=0.01)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Horizontal"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""d946115e-5a4d-460c-8a6c-626c4292dfe3"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Key and Mouse"",
                    ""action"": ""Horizontal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""2a0a1170-1284-41c1-a5e8-365989b8e32e"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Key and Mouse"",
                    ""action"": ""Horizontal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""16b50195-8a6f-48e3-9605-175654025c91"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": ""Press(behavior=2)"",
                    ""processors"": """",
                    ""groups"": ""Key and Mouse"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""896bae2c-a976-4c36-8512-9cc38b8e098e"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": ""Key and Mouse"",
                    ""action"": ""Magical"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2c1bf686-767e-4d87-918b-4443e079cec5"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Key and Mouse"",
                    ""action"": ""Swap"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6b961935-13f0-4c59-87f5-631cf91b2bd8"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Key and Mouse"",
                    ""action"": ""Counter"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d0a57dc7-f42b-404a-b15e-2bd8cfaa2753"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": ""Key and Mouse"",
                    ""action"": ""Physical"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a3aa8181-6a10-4617-8775-cfdd63d440f6"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": ""Press(behavior=2)"",
                    ""processors"": """",
                    ""groups"": ""Key and Mouse"",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9815fd13-bc7e-48b9-808a-96249494a005"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": ""Press(behavior=2)"",
                    ""processors"": """",
                    ""groups"": ""Key and Mouse"",
                    ""action"": ""Up"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a8aaf919-7825-4351-98d7-035322128ca2"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": ""Press(behavior=2)"",
                    ""processors"": """",
                    ""groups"": ""Key and Mouse"",
                    ""action"": ""Down"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""New action map"",
            ""id"": ""90b8c42c-6edc-4fbd-a6d8-fba539a33a69"",
            ""actions"": [
                {
                    ""name"": ""New action"",
                    ""type"": ""Button"",
                    ""id"": ""01aa7ab4-9dce-43da-9fe4-4c7f956ef5ed"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""77c7a6c5-caaf-4ce3-8f27-f5a33a57fb2d"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""New action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Key and Mouse"",
            ""bindingGroup"": ""Key and Mouse"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Gameplay
        m_Gameplay = asset.FindActionMap("Gameplay", throwIfNotFound: true);
        m_Gameplay_Horizontal = m_Gameplay.FindAction("Horizontal", throwIfNotFound: true);
        m_Gameplay_Jump = m_Gameplay.FindAction("Jump", throwIfNotFound: true);
        m_Gameplay_Dash = m_Gameplay.FindAction("Dash", throwIfNotFound: true);
        m_Gameplay_Physical = m_Gameplay.FindAction("Physical", throwIfNotFound: true);
        m_Gameplay_Magical = m_Gameplay.FindAction("Magical", throwIfNotFound: true);
        m_Gameplay_Swap = m_Gameplay.FindAction("Swap", throwIfNotFound: true);
        m_Gameplay_Counter = m_Gameplay.FindAction("Counter", throwIfNotFound: true);
        m_Gameplay_Up = m_Gameplay.FindAction("Up", throwIfNotFound: true);
        m_Gameplay_Down = m_Gameplay.FindAction("Down", throwIfNotFound: true);
        // New action map
        m_Newactionmap = asset.FindActionMap("New action map", throwIfNotFound: true);
        m_Newactionmap_Newaction = m_Newactionmap.FindAction("New action", throwIfNotFound: true);
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

    // Gameplay
    private readonly InputActionMap m_Gameplay;
    private IGameplayActions m_GameplayActionsCallbackInterface;
    private readonly InputAction m_Gameplay_Horizontal;
    private readonly InputAction m_Gameplay_Jump;
    private readonly InputAction m_Gameplay_Dash;
    private readonly InputAction m_Gameplay_Physical;
    private readonly InputAction m_Gameplay_Magical;
    private readonly InputAction m_Gameplay_Swap;
    private readonly InputAction m_Gameplay_Counter;
    private readonly InputAction m_Gameplay_Up;
    private readonly InputAction m_Gameplay_Down;
    public struct GameplayActions
    {
        private @PlayerCont m_Wrapper;
        public GameplayActions(@PlayerCont wrapper) { m_Wrapper = wrapper; }
        public InputAction @Horizontal => m_Wrapper.m_Gameplay_Horizontal;
        public InputAction @Jump => m_Wrapper.m_Gameplay_Jump;
        public InputAction @Dash => m_Wrapper.m_Gameplay_Dash;
        public InputAction @Physical => m_Wrapper.m_Gameplay_Physical;
        public InputAction @Magical => m_Wrapper.m_Gameplay_Magical;
        public InputAction @Swap => m_Wrapper.m_Gameplay_Swap;
        public InputAction @Counter => m_Wrapper.m_Gameplay_Counter;
        public InputAction @Up => m_Wrapper.m_Gameplay_Up;
        public InputAction @Down => m_Wrapper.m_Gameplay_Down;
        public InputActionMap Get() { return m_Wrapper.m_Gameplay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameplayActions set) { return set.Get(); }
        public void SetCallbacks(IGameplayActions instance)
        {
            if (m_Wrapper.m_GameplayActionsCallbackInterface != null)
            {
                @Horizontal.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnHorizontal;
                @Horizontal.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnHorizontal;
                @Horizontal.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnHorizontal;
                @Jump.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnJump;
                @Dash.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDash;
                @Dash.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDash;
                @Dash.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDash;
                @Physical.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPhysical;
                @Physical.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPhysical;
                @Physical.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPhysical;
                @Magical.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMagical;
                @Magical.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMagical;
                @Magical.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMagical;
                @Swap.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSwap;
                @Swap.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSwap;
                @Swap.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSwap;
                @Counter.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnCounter;
                @Counter.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnCounter;
                @Counter.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnCounter;
                @Up.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnUp;
                @Up.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnUp;
                @Up.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnUp;
                @Down.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDown;
                @Down.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDown;
                @Down.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDown;
            }
            m_Wrapper.m_GameplayActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Horizontal.started += instance.OnHorizontal;
                @Horizontal.performed += instance.OnHorizontal;
                @Horizontal.canceled += instance.OnHorizontal;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Dash.started += instance.OnDash;
                @Dash.performed += instance.OnDash;
                @Dash.canceled += instance.OnDash;
                @Physical.started += instance.OnPhysical;
                @Physical.performed += instance.OnPhysical;
                @Physical.canceled += instance.OnPhysical;
                @Magical.started += instance.OnMagical;
                @Magical.performed += instance.OnMagical;
                @Magical.canceled += instance.OnMagical;
                @Swap.started += instance.OnSwap;
                @Swap.performed += instance.OnSwap;
                @Swap.canceled += instance.OnSwap;
                @Counter.started += instance.OnCounter;
                @Counter.performed += instance.OnCounter;
                @Counter.canceled += instance.OnCounter;
                @Up.started += instance.OnUp;
                @Up.performed += instance.OnUp;
                @Up.canceled += instance.OnUp;
                @Down.started += instance.OnDown;
                @Down.performed += instance.OnDown;
                @Down.canceled += instance.OnDown;
            }
        }
    }
    public GameplayActions @Gameplay => new GameplayActions(this);

    // New action map
    private readonly InputActionMap m_Newactionmap;
    private INewactionmapActions m_NewactionmapActionsCallbackInterface;
    private readonly InputAction m_Newactionmap_Newaction;
    public struct NewactionmapActions
    {
        private @PlayerCont m_Wrapper;
        public NewactionmapActions(@PlayerCont wrapper) { m_Wrapper = wrapper; }
        public InputAction @Newaction => m_Wrapper.m_Newactionmap_Newaction;
        public InputActionMap Get() { return m_Wrapper.m_Newactionmap; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(NewactionmapActions set) { return set.Get(); }
        public void SetCallbacks(INewactionmapActions instance)
        {
            if (m_Wrapper.m_NewactionmapActionsCallbackInterface != null)
            {
                @Newaction.started -= m_Wrapper.m_NewactionmapActionsCallbackInterface.OnNewaction;
                @Newaction.performed -= m_Wrapper.m_NewactionmapActionsCallbackInterface.OnNewaction;
                @Newaction.canceled -= m_Wrapper.m_NewactionmapActionsCallbackInterface.OnNewaction;
            }
            m_Wrapper.m_NewactionmapActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Newaction.started += instance.OnNewaction;
                @Newaction.performed += instance.OnNewaction;
                @Newaction.canceled += instance.OnNewaction;
            }
        }
    }
    public NewactionmapActions @Newactionmap => new NewactionmapActions(this);
    private int m_KeyandMouseSchemeIndex = -1;
    public InputControlScheme KeyandMouseScheme
    {
        get
        {
            if (m_KeyandMouseSchemeIndex == -1) m_KeyandMouseSchemeIndex = asset.FindControlSchemeIndex("Key and Mouse");
            return asset.controlSchemes[m_KeyandMouseSchemeIndex];
        }
    }
    public interface IGameplayActions
    {
        void OnHorizontal(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnDash(InputAction.CallbackContext context);
        void OnPhysical(InputAction.CallbackContext context);
        void OnMagical(InputAction.CallbackContext context);
        void OnSwap(InputAction.CallbackContext context);
        void OnCounter(InputAction.CallbackContext context);
        void OnUp(InputAction.CallbackContext context);
        void OnDown(InputAction.CallbackContext context);
    }
    public interface INewactionmapActions
    {
        void OnNewaction(InputAction.CallbackContext context);
    }
}