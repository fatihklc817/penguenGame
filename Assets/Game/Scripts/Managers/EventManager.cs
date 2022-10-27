using Game.Scripts.Managers;
using Game.Scripts.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Scripts.Managers
{
    public class EventManager : CustomBehaviour
    {
        public event Action OnStartGame;


        public override void Initialize(GameManager gameManager)
        {
            base.Initialize(gameManager);
        }


        public void StartGame()
        {
            OnStartGame?.Invoke();
        }

    }
}
