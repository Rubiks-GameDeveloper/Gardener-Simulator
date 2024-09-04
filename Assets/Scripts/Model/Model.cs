using UnityEngine;
using UnityEngine.InputSystem;

public abstract class Model
{
    protected View _view;
    protected float _speed = 2;
    
    [SerializeField] private protected float xSens = 2;
    [SerializeField] private protected float ySens = 2;

    protected Camera _camera;
    protected Transform _playerCharacterParent;
    
    
    public Model(View view, Transform parent)
    {
        _view = view;
        _camera = Camera.main;
        _playerCharacterParent = parent;
    }

    public float GetXSens() => xSens;
    public float GetYSens() => ySens;

    public float GetSpeed() => _speed;
    public Camera GetCamera() => _camera;
    public Transform GetPlayerParent() => _playerCharacterParent;
    public PlayerInput GetPlayerInput() => _view.GetPlayerInput();
}
