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
        touchControls.Gameplay.Move.started += ctx => StartTouch(ctx);
        touchControls.Gameplay.Move.canceled += ctx => EndTouch(ctx);
    }
    
    private void StartTouch(InputAction.CallbackContext ctx)
    {
        Debug.Log($"Touch started {touchControls.Gameplay.Move.ReadValue<Vector2>()}");
    }

    private void EndTouch(InputAction.CallbackContext ctx)
    {
        Debug.Log($"Touch ended {touchControls.Gameplay.Move.ReadValue<Vector2>()}");
    }
}
