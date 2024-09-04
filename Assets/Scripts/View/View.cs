using UnityEngine;
using UnityEngine.InputSystem;

public abstract class View : MonoBehaviour
{
    protected Presenter _presenter;
    
    protected PlayerInput _playerInput;

    public abstract void Init(Presenter presenter);

    public PlayerInput GetPlayerInput() => _playerInput;
}
