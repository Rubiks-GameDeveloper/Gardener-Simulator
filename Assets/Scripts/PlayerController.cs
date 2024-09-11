using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;

public class PlayerController : MonoBehaviour, IMovement
{
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private CharacterController characterController;
    [SerializeField] private Transform parent;
    
    [Range(0.2f, 5)]
    [SerializeField] private float speed = 2;

    private Vector2 _moveInput;
    private Camera _playerCam;
    private float _camXRotation;
    private void Awake()
    {
        playerInput = FindObjectOfType<PlayerInput>();
        _playerCam = FindObjectOfType<Camera>();

        playerInput.actions.FindAction("Move").performed += OnMoveDataChanged;
        playerInput.actions.FindAction("Move").canceled += ClearMoveData;

        Application.targetFrameRate = 90;
        TouchSimulation.Enable();
    }
    private Vector3 CalculateMoveDir()
    {
        var direction = parent.forward * _moveInput.y + parent.right * _moveInput.x;

        return direction * speed;
    }
    private void Update()
    {
        if (!characterController.isGrounded)
        {
            Move(transform.up * -1);
            return;
        }
        Move(CalculateMoveDir());
    }

    public void OnMoveDataChanged(InputAction.CallbackContext context)
    {
        _moveInput = context.ReadValue<Vector2>();
    }
    public void ClearMoveData(InputAction.CallbackContext context)
    {
        _moveInput = Vector2.zero;
    }
    public void Move(Vector3 direction)
    {
        characterController.Move(direction * Time.deltaTime);
    }
    public void RotatePlayer(Vector2 delta)
    {
        var mouseX = delta.x * 5 * Time.deltaTime;
        var mouseY = delta.y * 5 * Time.deltaTime;

        _camXRotation -= mouseY;

        _camXRotation = Mathf.Clamp(_camXRotation, -90, 90);

        _playerCam.transform.localRotation = Quaternion.Euler(_camXRotation,0,0);
        parent.Rotate(Vector3.up * mouseX);
    }
}
