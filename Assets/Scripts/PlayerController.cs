using System;
using UnityEngine;
[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour, IMovement
{
    [SerializeField] private CharacterController characterController;
    [SerializeField] private Transform parent;
    
    [Range(0.2f, 5)]
    [SerializeField] private float speed = 2;

    private PlayerInputs _inputPlayer;
    private CameraInput _cameraInput;
    private float _camXRotation;
    private void Awake()
    {
        _inputPlayer = FindObjectOfType<PlayerInputs>();
        _cameraInput = FindObjectOfType<CameraInput>();
    }

    private void OnEnable()
    {
        _cameraInput.OnCameraPositionChange += RotatePlayer;
    }

    private Vector3 CalculateMoveDir()
    {
        var direction = parent.forward * _inputPlayer.MoveInput.y + parent.right * _inputPlayer.MoveInput.x;

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
    private void Move(Vector3 direction)
    {
        characterController.Move(direction * Time.deltaTime);
    }
    public void RotatePlayer(Vector2 delta)
    {
        var mouseX = delta.x * 5 * Time.deltaTime;
        var mouseY = delta.y * 5 * Time.deltaTime;

        _camXRotation -= mouseY;

        _camXRotation = Mathf.Clamp(_camXRotation, -90, 90);

        _inputPlayer.CameraInput.transform.localRotation = Quaternion.Euler(_camXRotation,0,0);
        parent.Rotate(Vector3.up * mouseX);
    }

    private void OnDisable()
    {
        print(2);
        _cameraInput.OnCameraPositionChange -= RotatePlayer;
    }
}
