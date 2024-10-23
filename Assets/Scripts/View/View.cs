using UnityEngine;
using UnityEngine.InputSystem;

public abstract class View : MonoBehaviour
{
    protected Presenter _presenter;
    

    public abstract void Init(Presenter presenter);

}
