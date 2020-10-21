// GENERATED AUTOMATICALLY FROM 'Assets/Inputs/Keyboard.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @Keyboard : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @Keyboard()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Keyboard"",
    ""maps"": [
        {
            ""name"": ""Game"",
            ""id"": ""54556d19-e2ae-4183-8569-7b907a568e65"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""90e77c0c-cbd3-47c6-8f33-cad09d31fa5a"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Cam"",
                    ""type"": ""Value"",
                    ""id"": ""b9f9468b-0c69-43c2-a8e0-73f4af255c74"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Swap"",
                    ""type"": ""Button"",
                    ""id"": ""72e52ec8-4428-44e5-abdd-eb007a4ed89c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""46db4afb-3b9c-4b73-8613-065b28f3d5f1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Hi5"",
                    ""type"": ""Button"",
                    ""id"": ""9da61066-77f7-4fb0-8b86-c90bbdc50700"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""b83519e6-1443-46aa-b7b5-bc94f8d27e5a"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""e3a29e4d-e056-4076-bc27-18944f85861f"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""06af79a1-51b5-4330-aa6f-2eb1591efb4b"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""2badc150-20c0-407b-b03d-148e280f7298"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""5fc8b8d8-00a4-4763-a62e-d6f2494384cf"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""9ebae39b-c629-4384-9865-46a8dbc2a377"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Cam"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8b666a77-902a-4656-a721-3fa4e548e02b"",
                    ""path"": ""<Keyboard>/anyKey"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Swap"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""84fec1f6-aeaf-4c05-a344-eb407759f3c4"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c26149c1-5dee-472c-a67e-0027920ec4a6"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Hi5"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""LockPuzzle"",
            ""id"": ""75976ec2-895c-4d6a-b5eb-7b0e7026986c"",
            ""actions"": [
                {
                    ""name"": ""NumUp"",
                    ""type"": ""Button"",
                    ""id"": ""52a5e378-e728-463b-9ccc-6be086ff89fb"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""NumDown"",
                    ""type"": ""Button"",
                    ""id"": ""8505515f-b08b-45c6-801d-d47a6f27cabd"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""LockLeft"",
                    ""type"": ""Button"",
                    ""id"": ""e6a4c3d4-1edf-40ad-bd0e-3f8124ddef2f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Lockright"",
                    ""type"": ""Button"",
                    ""id"": ""6016b7f6-2ad5-410c-81e5-5543fa3ef0da"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""6b7c563e-81e1-4148-adff-09f024fa3abc"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""NumUp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e8112d72-3940-4e3c-ad18-f129b23bf9d2"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""NumDown"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ea377ae6-5ca2-437f-9fb8-979e90396ba1"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LockLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bcd6f8ed-035b-4dad-924c-529b69e17b9d"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Lockright"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Game
        m_Game = asset.FindActionMap("Game", throwIfNotFound: true);
        m_Game_Move = m_Game.FindAction("Move", throwIfNotFound: true);
        m_Game_Cam = m_Game.FindAction("Cam", throwIfNotFound: true);
        m_Game_Swap = m_Game.FindAction("Swap", throwIfNotFound: true);
        m_Game_Interact = m_Game.FindAction("Interact", throwIfNotFound: true);
        m_Game_Hi5 = m_Game.FindAction("Hi5", throwIfNotFound: true);
        // LockPuzzle
        m_LockPuzzle = asset.FindActionMap("LockPuzzle", throwIfNotFound: true);
        m_LockPuzzle_NumUp = m_LockPuzzle.FindAction("NumUp", throwIfNotFound: true);
        m_LockPuzzle_NumDown = m_LockPuzzle.FindAction("NumDown", throwIfNotFound: true);
        m_LockPuzzle_LockLeft = m_LockPuzzle.FindAction("LockLeft", throwIfNotFound: true);
        m_LockPuzzle_Lockright = m_LockPuzzle.FindAction("Lockright", throwIfNotFound: true);
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

    // Game
    private readonly InputActionMap m_Game;
    private IGameActions m_GameActionsCallbackInterface;
    private readonly InputAction m_Game_Move;
    private readonly InputAction m_Game_Cam;
    private readonly InputAction m_Game_Swap;
    private readonly InputAction m_Game_Interact;
    private readonly InputAction m_Game_Hi5;
    public struct GameActions
    {
        private @Keyboard m_Wrapper;
        public GameActions(@Keyboard wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Game_Move;
        public InputAction @Cam => m_Wrapper.m_Game_Cam;
        public InputAction @Swap => m_Wrapper.m_Game_Swap;
        public InputAction @Interact => m_Wrapper.m_Game_Interact;
        public InputAction @Hi5 => m_Wrapper.m_Game_Hi5;
        public InputActionMap Get() { return m_Wrapper.m_Game; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameActions set) { return set.Get(); }
        public void SetCallbacks(IGameActions instance)
        {
            if (m_Wrapper.m_GameActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_GameActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_GameActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_GameActionsCallbackInterface.OnMove;
                @Cam.started -= m_Wrapper.m_GameActionsCallbackInterface.OnCam;
                @Cam.performed -= m_Wrapper.m_GameActionsCallbackInterface.OnCam;
                @Cam.canceled -= m_Wrapper.m_GameActionsCallbackInterface.OnCam;
                @Swap.started -= m_Wrapper.m_GameActionsCallbackInterface.OnSwap;
                @Swap.performed -= m_Wrapper.m_GameActionsCallbackInterface.OnSwap;
                @Swap.canceled -= m_Wrapper.m_GameActionsCallbackInterface.OnSwap;
                @Interact.started -= m_Wrapper.m_GameActionsCallbackInterface.OnInteract;
                @Interact.performed -= m_Wrapper.m_GameActionsCallbackInterface.OnInteract;
                @Interact.canceled -= m_Wrapper.m_GameActionsCallbackInterface.OnInteract;
                @Hi5.started -= m_Wrapper.m_GameActionsCallbackInterface.OnHi5;
                @Hi5.performed -= m_Wrapper.m_GameActionsCallbackInterface.OnHi5;
                @Hi5.canceled -= m_Wrapper.m_GameActionsCallbackInterface.OnHi5;
            }
            m_Wrapper.m_GameActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Cam.started += instance.OnCam;
                @Cam.performed += instance.OnCam;
                @Cam.canceled += instance.OnCam;
                @Swap.started += instance.OnSwap;
                @Swap.performed += instance.OnSwap;
                @Swap.canceled += instance.OnSwap;
                @Interact.started += instance.OnInteract;
                @Interact.performed += instance.OnInteract;
                @Interact.canceled += instance.OnInteract;
                @Hi5.started += instance.OnHi5;
                @Hi5.performed += instance.OnHi5;
                @Hi5.canceled += instance.OnHi5;
            }
        }
    }
    public GameActions @Game => new GameActions(this);

    // LockPuzzle
    private readonly InputActionMap m_LockPuzzle;
    private ILockPuzzleActions m_LockPuzzleActionsCallbackInterface;
    private readonly InputAction m_LockPuzzle_NumUp;
    private readonly InputAction m_LockPuzzle_NumDown;
    private readonly InputAction m_LockPuzzle_LockLeft;
    private readonly InputAction m_LockPuzzle_Lockright;
    public struct LockPuzzleActions
    {
        private @Keyboard m_Wrapper;
        public LockPuzzleActions(@Keyboard wrapper) { m_Wrapper = wrapper; }
        public InputAction @NumUp => m_Wrapper.m_LockPuzzle_NumUp;
        public InputAction @NumDown => m_Wrapper.m_LockPuzzle_NumDown;
        public InputAction @LockLeft => m_Wrapper.m_LockPuzzle_LockLeft;
        public InputAction @Lockright => m_Wrapper.m_LockPuzzle_Lockright;
        public InputActionMap Get() { return m_Wrapper.m_LockPuzzle; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(LockPuzzleActions set) { return set.Get(); }
        public void SetCallbacks(ILockPuzzleActions instance)
        {
            if (m_Wrapper.m_LockPuzzleActionsCallbackInterface != null)
            {
                @NumUp.started -= m_Wrapper.m_LockPuzzleActionsCallbackInterface.OnNumUp;
                @NumUp.performed -= m_Wrapper.m_LockPuzzleActionsCallbackInterface.OnNumUp;
                @NumUp.canceled -= m_Wrapper.m_LockPuzzleActionsCallbackInterface.OnNumUp;
                @NumDown.started -= m_Wrapper.m_LockPuzzleActionsCallbackInterface.OnNumDown;
                @NumDown.performed -= m_Wrapper.m_LockPuzzleActionsCallbackInterface.OnNumDown;
                @NumDown.canceled -= m_Wrapper.m_LockPuzzleActionsCallbackInterface.OnNumDown;
                @LockLeft.started -= m_Wrapper.m_LockPuzzleActionsCallbackInterface.OnLockLeft;
                @LockLeft.performed -= m_Wrapper.m_LockPuzzleActionsCallbackInterface.OnLockLeft;
                @LockLeft.canceled -= m_Wrapper.m_LockPuzzleActionsCallbackInterface.OnLockLeft;
                @Lockright.started -= m_Wrapper.m_LockPuzzleActionsCallbackInterface.OnLockright;
                @Lockright.performed -= m_Wrapper.m_LockPuzzleActionsCallbackInterface.OnLockright;
                @Lockright.canceled -= m_Wrapper.m_LockPuzzleActionsCallbackInterface.OnLockright;
            }
            m_Wrapper.m_LockPuzzleActionsCallbackInterface = instance;
            if (instance != null)
            {
                @NumUp.started += instance.OnNumUp;
                @NumUp.performed += instance.OnNumUp;
                @NumUp.canceled += instance.OnNumUp;
                @NumDown.started += instance.OnNumDown;
                @NumDown.performed += instance.OnNumDown;
                @NumDown.canceled += instance.OnNumDown;
                @LockLeft.started += instance.OnLockLeft;
                @LockLeft.performed += instance.OnLockLeft;
                @LockLeft.canceled += instance.OnLockLeft;
                @Lockright.started += instance.OnLockright;
                @Lockright.performed += instance.OnLockright;
                @Lockright.canceled += instance.OnLockright;
            }
        }
    }
    public LockPuzzleActions @LockPuzzle => new LockPuzzleActions(this);
    public interface IGameActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnCam(InputAction.CallbackContext context);
        void OnSwap(InputAction.CallbackContext context);
        void OnInteract(InputAction.CallbackContext context);
        void OnHi5(InputAction.CallbackContext context);
    }
    public interface ILockPuzzleActions
    {
        void OnNumUp(InputAction.CallbackContext context);
        void OnNumDown(InputAction.CallbackContext context);
        void OnLockLeft(InputAction.CallbackContext context);
        void OnLockright(InputAction.CallbackContext context);
    }
}
