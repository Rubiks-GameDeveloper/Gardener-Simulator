using UnityEngine;
using UnityEngine.InputSystem;

public abstract class Model
{
    protected View _view;
    
    public Model(View view)
    {
        _view = view;
    }
}
