using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantBuildFocus : FocusScript
{
    public override Vector3 GetFocusPlacePos(Vector3 rayTouchPos)
    {
        return transform.position;
    }
}
