using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlantItem", menuName = "ItemData/PlantItem")]
public class PlantItem : Item
{
    [SerializeField] private Season season;
    [SerializeField] private GameObject plantWorldPrefab;

    public Season GetSeason() => season;
    public GameObject GetWorldPrefab() => plantWorldPrefab;
}

public enum Season
{
    Winter,
    Spring,
    Summer,
    Autumn
}
