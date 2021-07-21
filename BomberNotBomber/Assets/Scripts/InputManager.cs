using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private TouchControls touchControls;

    private void Awake()
    {
        touchControls = new TouchControls();

    }

    private void OnEnable()
    {
        touchControls.Enable();
    }

    private void OnDisable()
    {
        touchControls.Disable();
    }

    private void Start()
    {
        touchControls.Gameplay.TouchPress.started += ctx => StartTouch(ctx);
        touchControls.Gameplay.TouchPress.canceled += ctx => EndTouch(ctx);
    }
    
    private void StartTouch(InputAction.CallbackContext ctx)
    {
        Debug.Log($"Touch started {touchControls.Gameplay.TouchPosition.ReadValue<Vector2>()}");
    }

    private void EndTouch(InputAction.CallbackContext ctx)
    {
        Debug.Log($"Touch ended {touchControls.Gameplay.TouchPosition.ReadValue<Vector2>()}");
    }
}
