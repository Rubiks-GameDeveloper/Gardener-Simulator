using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class CameraInput : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerMoveHandler
{
    private Vector2 _delta;

    public Action<Vector2> OnCameraPositionChange;

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
        
        OnCameraPositionChange?.Invoke(-_delta);
        
        _delta = eventData.position;
    }
    
    
}
