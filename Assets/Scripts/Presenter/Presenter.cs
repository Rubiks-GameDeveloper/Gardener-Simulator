using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public abstract class Presenter
{
    protected Model _model;
    protected CharacterControllerMove _characterControllerMove;
    public Presenter(Model model, CharacterControllerMove characterControllerMove)
    {
        _model = model;
        _characterControllerMove = characterControllerMove;
    }

    public abstract void SetRotateData(InputAction.CallbackContext context);
    public abstract void SetMoveData(InputAction.CallbackContext context);
}
