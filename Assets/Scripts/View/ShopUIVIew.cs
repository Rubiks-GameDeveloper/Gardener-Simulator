using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerUIInputs))]
public class ShopUIVIew : View
{
    private ShopUIPresenter _shopUIPresenter;
    private PlayerUIInputs _playerUIInputs;
    
    [SerializeField] private GameObject itemContainer;
    [SerializeField] private GameObject itemUIPrefab;

    private void Awake()
    {
        _playerUIInputs = FindObjectOfType<PlayerUIInputs>();
    }

    public override void Init(Presenter presenter)
    {
        _shopUIPresenter = (ShopUIPresenter)presenter;
        
    }
    public void InitializeShopItems(List<Item> items)
    {
        foreach (var item in items)
        {
            var uiItem = Instantiate(itemUIPrefab, itemContainer.transform).GetComponent<UIPlantItem>();
            uiItem.SetStartData(item);
            uiItem.GetSelectButton().onClick.AddListener(() => _shopUIPresenter.SelectItem(item));
        }
    }

    public void UpdateShopList()
    {
        
    }
}
