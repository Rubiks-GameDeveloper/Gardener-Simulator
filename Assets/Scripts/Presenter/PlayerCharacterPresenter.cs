using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCharacterPresenter : Presenter
{
    [SerializeField] private PlayerInput playerInput;

    private InputAction _moveAction;
    private InputAction _rotateAction;

    public PlayerCharacterPresenter(Model model, CharacterControllerMove controllerMove) : base(model, controllerMove)
    {
        _model = model;
    }

    private void Awake()
    {
        playerInput = _model.GetPlayerInput();

        _moveAction = playerInput.actions.FindAction("Move");
        _rotateAction = playerInput.actions.FindAction("Drag");
        
    }

    public void RotateCamera(Vector2 readValue)
    {
        var mouseX = readValue.x * _model.GetXSens() * Time.deltaTime;
        var mouseY = readValue.y * _model.GetYSens() * Time.deltaTime;

        var _xRotation = -mouseY;
        _xRotation = Mathf.Clamp(_xRotation, -90, 90);

        //Debug.Assert(Camera.main != null, "Camera.main != null");
        _model.GetCamera().transform.localRotation = Quaternion.Euler(_xRotation, 0, 0);
        //_model.GetPlayerParent().Rotate(Vector3.up * mouseX);
    }

    public override void SetMoveData(InputAction.CallbackContext context)
    {
        var inputValue = new Vector3(context.ReadValue<Vector2>().x, 0, context.ReadValue<Vector2>().y);
        var parent = _model.GetPlayerParent();

        var speed = _model.GetSpeed();

        //var dir = new Vector3(parent.right.x * inputValue.x * speed, 0,  Vector3.ProjectOnPlane(parent.forward, inputValue));

        var dir = Vector3.Project(inputValue, parent.forward) * speed;
        
        Debug.Log(dir + " DIRECTION");
        
        _characterControllerMove.Move(dir);
    }

    public override void SetRotateData(InputAction.CallbackContext context)
    {
        RotateCamera(context.ReadValue<Vector2>());
    }
}
