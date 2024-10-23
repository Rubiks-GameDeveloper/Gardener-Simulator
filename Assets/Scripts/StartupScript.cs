using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartupScript : MonoBehaviour
{
    [SerializeField] private ShopUIVIew characterView;
    [SerializeField] private List<Item> allPlants;
    private void Awake()
    {
        var model = new ShopUIModel(characterView, allPlants);
        Presenter presenter = new ShopUIPresenter(model, characterView);
        
        characterView.Init(presenter);
    }
}
