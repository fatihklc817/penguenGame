using Game.Scripts.Utilities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Scripts.Managers
{
    public class GameManager : CustomBehaviour
    {

        public EventManager EventManager;
        public PlayerController PlayerController;
        public CustomerController CustomerController;
        public KitchenManager KitchenManager;


        private void Awake()
        {
            EventManager.Initialize(this);
            PlayerController.Initialize(this);
            CustomerController.Initialize(this);
            KitchenManager.Initialize(this);
        }
    }
}
