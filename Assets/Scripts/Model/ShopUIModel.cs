using System;
using System.Collections.Generic;
public class ShopUIModel : Model
{
    private int moneyCount;
    public GameObjectPlacer GameObjectPlacer { get; private set; }
    public event Action plantsListChange;
    public List<Item> plants { get; private set; }
    private ShopUIVIew _shopUIView;
    public ShopUIModel(View view, List<Item> plants, GameObjectPlacer gameObjectPlacer) : base(view)
    {
        this.plants = plants;
        _shopUIView = (ShopUIVIew)view;
        GameObjectPlacer = gameObjectPlacer;
    }
    
    
}
