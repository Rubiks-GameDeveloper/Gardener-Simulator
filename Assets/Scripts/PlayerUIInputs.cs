using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerUIInputs : MonoBehaviour
{
    private PlayerInput _input;

    [SerializeField] private GameObject shopUI;
    private void Start()
    {
        _input = FindObjectOfType<PlayerInput>();

        _input.actions.FindAction("OpenShop").performed += ShopVisibilityChange;
    }

    private void ShopVisibilityChange(InputAction.CallbackContext obj)
    {
        shopUI.SetActive(!shopUI.activeSelf);
    }
    public void ShopVisibilityChange()
    {
        shopUI.SetActive(!shopUI.activeSelf);
    }
}
