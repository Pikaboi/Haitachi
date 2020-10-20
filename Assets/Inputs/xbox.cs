// GENERATED AUTOMATICALLY FROM 'Assets/Inputs/xbox.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @Xbox : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @Xbox()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""xbox"",
    ""maps"": [
        {
            ""name"": ""Game"",
            ""id"": ""84cce86a-375b-40c0-ada3-9430392b3ecc"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Button"",
                    ""id"": ""f808c4e1-8d7c-42e8-b6c3-107642467cc3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Cam"",
                    ""type"": ""Button"",
                    ""id"": ""b0dec24b-8975-4c41-97a5-846aab0ded12"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Swap"",
                    ""type"": ""Button"",
                    ""id"": ""6a471dbd-11e1-4294-9a1d-9a2b65d2eb03"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""49cfa2ba-9c6a-4056-a7c8-03aecda6e95f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""0d808e52-4336-40f7-bf28-7cf7cfb198e0"",
                    ""path"": ""<GamePad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1b48ed78-1a83-4432-a94d-3fe90e7912da"",
                    ""path"": ""<GamePad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Cam"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0eb40b88-908d-40a4-a1b6-e82d53cf2cf4"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Swap"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8aa3a989-94ae-4c35-8c58-7f50195a4a66"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""LockPuzzle"",
            ""id"": ""ff965797-28c9-41f6-a472-75c1557d4e15"",
            ""actions"": [
                {
                    ""name"": ""NumUp"",
                    ""type"": ""Button"",
                    ""id"": ""ad8c3ea2-6fcd-4873-9d76-353708680c52"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""NumDown"",
                    ""type"": ""Button"",
                    ""id"": ""7fe64353-3c26-4f4c-8d21-449ad53a6444"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""LockLeft"",
                    ""type"": ""Button"",
                    ""id"": ""408cec46-61c5-47d0-8b25-a2922ca4064f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Lockright"",
                    ""type"": ""Button"",
                    ""id"": ""9aa802f7-33e6-4bd8-b4c1-984e2c1b061d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""302f1e0d-428c-48af-9255-dc0b6620c315"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""NumUp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f85cc41a-7900-4b36-9e18-93f7da78c7f4"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""NumDown"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ff51e954-52b5-4a8c-88a4-b3c3d418ff38"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LockLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9ada8280-bb51-49ca-a2fd-1f6ef539f315"",
                    ""path"": ""<Gamepad>/leftStick/right"",
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
    public struct GameActions
    {
        private @Xbox m_Wrapper;
        public GameActions(@Xbox wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Game_Move;
        public InputAction @Cam => m_Wrapper.m_Game_Cam;
        public InputAction @Swap => m_Wrapper.m_Game_Swap;
        public InputAction @Interact => m_Wrapper.m_Game_Interact;
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
        private @Xbox m_Wrapper;
        public LockPuzzleActions(@Xbox wrapper) { m_Wrapper = wrapper; }
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
    }
    public interface ILockPuzzleActions
    {
        void OnNumUp(InputAction.CallbackContext context);
        void OnNumDown(InputAction.CallbackContext context);
        void OnLockLeft(InputAction.CallbackContext context);
        void OnLockright(InputAction.CallbackContext context);
    }
}
