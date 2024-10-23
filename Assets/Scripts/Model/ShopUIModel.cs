using System;
using System.Collections.Generic;
public class ShopUIModel : Model
{
    private int moneyCount;
    public event Action plantsListChange;
    public List<Item> plants { get; private set; }
    private ShopUIVIew _shopUIView;
    public ShopUIModel(View view, List<Item> plants) : base(view)
    {
        this.plants = plants;
        _shopUIView = (ShopUIVIew)view;
    }
    
    
}
