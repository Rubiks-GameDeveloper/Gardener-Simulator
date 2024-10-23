using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public abstract class Presenter
{
    protected Model _model;
    protected View _view;
    public Presenter(Model model, View view)
    {
        _model = model;
        _view = view;
    }
}
