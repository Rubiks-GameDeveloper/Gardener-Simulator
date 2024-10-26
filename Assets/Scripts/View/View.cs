using UnityEngine;
using UnityEngine.InputSystem;

public abstract class View : MonoBehaviour
{
    protected Presenter _presenter;


    public virtual void Init(Presenter presenter)
    {
        _presenter = presenter;
    }
}
