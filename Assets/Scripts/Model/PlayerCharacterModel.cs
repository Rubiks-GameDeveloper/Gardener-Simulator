using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacterModel : Model
{
    public PlayerCharacterModel(View view, Transform transform) : base(view, transform)
    {
        _view = view;
        _playerCharacterParent = transform;
    }
}
