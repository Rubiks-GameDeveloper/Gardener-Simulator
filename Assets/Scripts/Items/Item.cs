using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : ScriptableObject
{
    [SerializeField] private int itemId;
    [SerializeField] private string description;

    public int GetId() => itemId;
    public string GetDescription() => description;
}
