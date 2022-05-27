using UnityEngine;

namespace Input
{
    public class PlayerInputHandler : MonoBehaviour
    {
        private Actions actions;
        private Actions.PlayerActions playerActions;
        
        private void Awake()
        {
            actions = new Actions();
            playerActions = actions.Player;
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