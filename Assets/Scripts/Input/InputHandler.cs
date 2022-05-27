using System;
using UnityEngine;

namespace Input
{
    public class InputHandler : MonoBehaviour, IPlayerInputSubject, IUIInputSubject
    {
        private Actions actions;
        
        public Actions.UIActions UIActions => actions.UI;
        public Actions.PlayerActions PlayerActions => actions.Player;

        private void Awake()
        {
            actions = new Actions();
        }

        private void OnEnable()
        {
            actions.Enable();
        }

        private void OnDisable()
        {
            actions.Disable();
        }
    }
}