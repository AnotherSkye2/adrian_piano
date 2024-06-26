//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/KeyboardInputActions.inputactions
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

public partial class @KeyboardInputActions: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @KeyboardInputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""KeyboardInputActions"",
    ""maps"": [
        {
            ""name"": ""Keyboard"",
            ""id"": ""d0fcb22b-23ec-47e9-bc19-6be679b176f9"",
            ""actions"": [
                {
                    ""name"": ""NoteColumn0"",
                    ""type"": ""Button"",
                    ""id"": ""0227609d-46a0-49dc-955b-9a2a40bd25d4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""NoteColumn1"",
                    ""type"": ""Button"",
                    ""id"": ""25892a98-ce81-4689-89d7-201ec4950ef8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""NoteColumn2"",
                    ""type"": ""Button"",
                    ""id"": ""463b1a59-ddcf-4cab-86fb-7d668156e8ba"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""NoteColumn3"",
                    ""type"": ""Button"",
                    ""id"": ""0b8a71ce-4bb4-474b-94be-7bff3b6278e0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""13cb20ad-e392-4fc4-a7d0-c575f6eeb419"",
                    ""path"": ""<Keyboard>/g"",
                    ""interactions"": """",
                    ""processors"": ""Scale(factor=0)"",
                    ""groups"": """",
                    ""action"": ""NoteColumn0"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0b06ae8b-b71a-465d-9cf2-d856a4ab1de3"",
                    ""path"": ""<Keyboard>/h"",
                    ""interactions"": """",
                    ""processors"": ""Scale"",
                    ""groups"": """",
                    ""action"": ""NoteColumn1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a5d9d49e-a108-4ceb-bdb6-0e9ca3d1942b"",
                    ""path"": ""<Keyboard>/j"",
                    ""interactions"": """",
                    ""processors"": ""Scale(factor=2)"",
                    ""groups"": """",
                    ""action"": ""NoteColumn2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cd6f00c4-fe9f-46d9-a145-ce07fa106362"",
                    ""path"": ""<Keyboard>/k"",
                    ""interactions"": """",
                    ""processors"": ""Scale(factor=3)"",
                    ""groups"": """",
                    ""action"": ""NoteColumn3"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Keyboard
        m_Keyboard = asset.FindActionMap("Keyboard", throwIfNotFound: true);
        m_Keyboard_NoteColumn0 = m_Keyboard.FindAction("NoteColumn0", throwIfNotFound: true);
        m_Keyboard_NoteColumn1 = m_Keyboard.FindAction("NoteColumn1", throwIfNotFound: true);
        m_Keyboard_NoteColumn2 = m_Keyboard.FindAction("NoteColumn2", throwIfNotFound: true);
        m_Keyboard_NoteColumn3 = m_Keyboard.FindAction("NoteColumn3", throwIfNotFound: true);
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

    // Keyboard
    private readonly InputActionMap m_Keyboard;
    private List<IKeyboardActions> m_KeyboardActionsCallbackInterfaces = new List<IKeyboardActions>();
    private readonly InputAction m_Keyboard_NoteColumn0;
    private readonly InputAction m_Keyboard_NoteColumn1;
    private readonly InputAction m_Keyboard_NoteColumn2;
    private readonly InputAction m_Keyboard_NoteColumn3;
    public struct KeyboardActions
    {
        private @KeyboardInputActions m_Wrapper;
        public KeyboardActions(@KeyboardInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @NoteColumn0 => m_Wrapper.m_Keyboard_NoteColumn0;
        public InputAction @NoteColumn1 => m_Wrapper.m_Keyboard_NoteColumn1;
        public InputAction @NoteColumn2 => m_Wrapper.m_Keyboard_NoteColumn2;
        public InputAction @NoteColumn3 => m_Wrapper.m_Keyboard_NoteColumn3;
        public InputActionMap Get() { return m_Wrapper.m_Keyboard; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(KeyboardActions set) { return set.Get(); }
        public void AddCallbacks(IKeyboardActions instance)
        {
            if (instance == null || m_Wrapper.m_KeyboardActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_KeyboardActionsCallbackInterfaces.Add(instance);
            @NoteColumn0.started += instance.OnNoteColumn0;
            @NoteColumn0.performed += instance.OnNoteColumn0;
            @NoteColumn0.canceled += instance.OnNoteColumn0;
            @NoteColumn1.started += instance.OnNoteColumn1;
            @NoteColumn1.performed += instance.OnNoteColumn1;
            @NoteColumn1.canceled += instance.OnNoteColumn1;
            @NoteColumn2.started += instance.OnNoteColumn2;
            @NoteColumn2.performed += instance.OnNoteColumn2;
            @NoteColumn2.canceled += instance.OnNoteColumn2;
            @NoteColumn3.started += instance.OnNoteColumn3;
            @NoteColumn3.performed += instance.OnNoteColumn3;
            @NoteColumn3.canceled += instance.OnNoteColumn3;
        }

        private void UnregisterCallbacks(IKeyboardActions instance)
        {
            @NoteColumn0.started -= instance.OnNoteColumn0;
            @NoteColumn0.performed -= instance.OnNoteColumn0;
            @NoteColumn0.canceled -= instance.OnNoteColumn0;
            @NoteColumn1.started -= instance.OnNoteColumn1;
            @NoteColumn1.performed -= instance.OnNoteColumn1;
            @NoteColumn1.canceled -= instance.OnNoteColumn1;
            @NoteColumn2.started -= instance.OnNoteColumn2;
            @NoteColumn2.performed -= instance.OnNoteColumn2;
            @NoteColumn2.canceled -= instance.OnNoteColumn2;
            @NoteColumn3.started -= instance.OnNoteColumn3;
            @NoteColumn3.performed -= instance.OnNoteColumn3;
            @NoteColumn3.canceled -= instance.OnNoteColumn3;
        }

        public void RemoveCallbacks(IKeyboardActions instance)
        {
            if (m_Wrapper.m_KeyboardActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IKeyboardActions instance)
        {
            foreach (var item in m_Wrapper.m_KeyboardActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_KeyboardActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public KeyboardActions @Keyboard => new KeyboardActions(this);
    public interface IKeyboardActions
    {
        void OnNoteColumn0(InputAction.CallbackContext context);
        void OnNoteColumn1(InputAction.CallbackContext context);
        void OnNoteColumn2(InputAction.CallbackContext context);
        void OnNoteColumn3(InputAction.CallbackContext context);
    }
}
