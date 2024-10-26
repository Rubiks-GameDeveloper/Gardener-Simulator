using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartupScript : MonoBehaviour
{
    [SerializeField] private ShopUIVIew characterView;
    [SerializeField] private List<Item> allPlants;
    [SerializeField] private GameObjectPlacer gameObjectPlacer;
    private void Awake()
    {
        var model = new ShopUIModel(characterView, allPlants, gameObjectPlacer);
        var presenter = new ShopUIPresenter(model, characterView);
        
        

        characterView.Init(presenter);
    }
}
