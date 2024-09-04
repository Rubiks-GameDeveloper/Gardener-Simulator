using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartupScript : MonoBehaviour
{
    [SerializeField] private PlayerCharacterView characterView;
    [SerializeField] private Transform characterParentTransform;
    private void Awake()
    {
        View prefab = characterView;

        var view = Instantiate(prefab, transform);
        var model = new PlayerCharacterModel(view, characterParentTransform);
        Presenter presenter = new PlayerCharacterPresenter(model, FindObjectOfType<CharacterControllerMove>());
        
        view.Init(presenter);
    }
}
