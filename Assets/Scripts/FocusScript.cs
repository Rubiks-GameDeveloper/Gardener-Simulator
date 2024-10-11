using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FocusScript : MonoBehaviour
{
    [Range(1, 15)]
    [SerializeField] private float focusRange;

    public float GetFocusRange()
    {
        return focusRange;
        
    }
    public abstract Vector3 GetFocusPlacePos(Vector3 rayTouchPos);
}
