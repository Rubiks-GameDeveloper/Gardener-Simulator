using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PlayerCharacterView : View, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private GameObject touchPanel;

    private InputAction _moveAction;
    private InputAction _rotationAction;

    public override void Init(Presenter presenter)
    {
        _presenter = presenter;
        
        playerInput = FindObjectOfType<PlayerInput>();
        _moveAction = playerInput.actions.FindAction("Move");
        _rotationAction = playerInput.actions.FindAction("Drag");

        _moveAction.performed += _presenter.SetMoveData;
    }

    private void Update()
    {
        
    }

    public void OnDisable()
    {
        _moveAction.performed -= _presenter.SetMoveData;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (eventData.pointerEnter.gameObject == touchPanel)
        {
            print("ENTER");
            _rotationAction.performed += _presenter.SetRotateData;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (eventData.pointerEnter.gameObject == touchPanel)
        {
            print("EXIT");
            
            _rotationAction.performed -= _presenter.SetRotateData;
        }
    }
}
