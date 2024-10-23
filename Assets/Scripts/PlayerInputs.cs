using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;

public class PlayerInputs : MonoBehaviour
{
    private PlayerInput _input;
    public Vector2 MoveInput { get; private set; }
    public Camera CameraInput { get; private set; }
    private void Awake()
    {
        Init();
        
        //
        Application.targetFrameRate = 90;
        TouchSimulation.Enable();
    }
    private void Init()
    {
        _input = FindObjectOfType<PlayerInput>();
        CameraInput = Camera.main;

        _input.actions.FindAction("Move").performed += OnMoveDataChanged;
        _input.actions.FindAction("Move").canceled += ClearMoveData;
    }
    private void OnMoveDataChanged(InputAction.CallbackContext context)
    {
        MoveInput = context.ReadValue<Vector2>();
    }
    private void ClearMoveData(InputAction.CallbackContext context)
    {
        MoveInput = Vector2.zero;
    }
}
