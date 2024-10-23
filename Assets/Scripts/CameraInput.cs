using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class CameraInput : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerMoveHandler
{
    private Vector2 _delta;
    private PlayerController _playerController;

    private void Start()
    {
        _playerController = FindObjectOfType<PlayerController>();
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        _delta = eventData.position;
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        _delta = Vector2.zero;
    }
    public void OnPointerMove(PointerEventData eventData)
    {
        _delta -= eventData.position;
        _playerController.RotatePlayer(-_delta);
        _delta = eventData.position;
    }
}
