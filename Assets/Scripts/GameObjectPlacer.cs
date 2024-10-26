using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Items;
using UnityEngine;
using UnityEngine.Rendering;

public class GameObjectPlacer : MonoBehaviour
{
    private Camera _mainCam;
    [SerializeField] private GameObject buildObject;

    [Range(3, 20)] [SerializeField] private float placeDistance;

    private void Start()
    {
        _mainCam = Camera.main;
    }

    public (RaycastHit hit, Ray ray) GetCameraRaycastInfo()
    {
        var ray = _mainCam.ScreenPointToRay(_mainCam.pixelRect.center);
        Physics.Raycast(ray, out var hit, placeDistance);
        
        Debug.DrawRay(ray.origin, ray.direction * placeDistance, Color.red);
        
        return (hit, ray);
    }

    private bool IsBuildItemSet()
    {
        return buildObject != null;
    }
    public void SetBuildItem(Item item)
    {
        buildObject = ((BuildItem)item).GetWorldBuildPrefab();
    }
    public void ClearBuildItem()
    {
        buildObject = null;
    }

    public void CalculateBuildItemPos()
    {
        if (!IsBuildItemSet()) return;

        var rayInfo = GetCameraRaycastInfo();

        var col = buildObject.GetComponent<Collider>();
        if (rayInfo.hit.transform == null)
        {
            buildObject.transform.position = rayInfo.ray.GetPoint(placeDistance) + new Vector3(0, col.bounds.extents.y, 0);
            buildObject.GetComponent<Renderer>().material.DisableKeyword("_CANBUILD");
            return;
        }

        FocusScript test;
        if (rayInfo.hit.transform.TryGetComponent(out test))
        {
            buildObject.transform.position =
                test.GetFocusPlacePos(rayInfo.hit.point) + new Vector3(0, col.bounds.extents.y, 0);
            buildObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            buildObject.transform.position = rayInfo.hit.point + new Vector3(0, col.bounds.extents.y, 0);
        }

        buildObject.GetComponent<Renderer>().material.EnableKeyword("_CANBUILD");
    }
}
