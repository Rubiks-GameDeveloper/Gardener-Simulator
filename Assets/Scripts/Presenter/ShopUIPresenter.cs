using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopUIPresenter : Presenter
{
    private ShopUIVIew _shopUIView;
    private ShopUIModel _shopUIModel;
    private GameObjectPlacer _objectBuilder;
    public ShopUIPresenter(Model model, View view) : base(model, view)
    {
        _shopUIView = (ShopUIVIew)view;
        _shopUIModel = (ShopUIModel)model;

        _shopUIView.InitializeShopItems(_shopUIModel.plants);
        _shopUIModel.plantsListChange += UpdateItemsUI;
        _objectBuilder = _shopUIModel.GameObjectPlacer;
        
        
    }

    public void SelectItem(Item item)
    {
        
    }

    public void UpdateItemsUI()
    {
        _shopUIView.UpdateShopList();
    }
}
