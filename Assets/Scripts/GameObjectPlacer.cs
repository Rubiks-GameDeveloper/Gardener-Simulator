using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Rendering;

public class GameObjectPlacer : MonoBehaviour
{
    private Camera _mainCam;
    [SerializeField] private GameObject testObj;

    [Range(3, 20)] [SerializeField] private float placeDistance;

    private void Start()
    {
        _mainCam = Camera.main;
        testObj.transform.SetParent(transform.parent);
    }

    private void Update()
    {
        RaycastHit res = new RaycastHit();
        var ray = _mainCam.ScreenPointToRay(_mainCam.pixelRect.center);
        Physics.Raycast(ray, out res, placeDistance);
        
        Debug.DrawRay(ray.origin, ray.direction * placeDistance, Color.red);
        
        var col = testObj.GetComponent<Collider>();
        if (res.transform == null)
        {
            testObj.transform.position = ray.GetPoint(placeDistance) + new Vector3(0, col.bounds.extents.y, 0);
            testObj.GetComponent<Renderer>().material.DisableKeyword("_CANBUILD");
            return;
        }
        FocusScript test;
        if (res.transform.TryGetComponent(out test))
        {
            testObj.transform.position = test.GetFocusPlacePos(res.point) + new Vector3(0, col.bounds.extents.y, 0);
            testObj.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            testObj.transform.position = res.point + new Vector3(0, col.bounds.extents.y, 0);
        }
        testObj.GetComponent<Renderer>().material.EnableKeyword("_CANBUILD");
    }
}
