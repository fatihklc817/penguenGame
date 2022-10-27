using Game.Scripts.Managers;
using Game.Scripts.Utilities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : CustomBehaviour
{

    [SerializeField] private PlayerMovementBehaviour _playerMovementBehaviour;
    
    public override void Initialize(GameManager gameManager)
    {
        base.Initialize(gameManager);
        _playerMovementBehaviour.Initialize(this);
    }


}
