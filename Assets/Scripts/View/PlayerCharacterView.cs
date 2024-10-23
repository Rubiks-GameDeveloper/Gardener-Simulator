using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PlayerCharacterView : View
{
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private GameObject touchPanel;

    private InputAction _moveAction;
    private InputAction _rotationAction;

    public override void Init(Presenter presenter)
    {
        
    }
}
