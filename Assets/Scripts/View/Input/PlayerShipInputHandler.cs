using Model.ShipModel.ShipInputHandler;
using UnityEngine;

namespace View.Input
{
    public abstract class PlayerShipInputHandler : IShipInputHandler
    {
        protected readonly InputActions InputActions;

        protected PlayerShipInputHandler()
        {
            InputActions = new InputActions();
            InputActions.Ship.Enable();
        }

        public float MoveInput => InputActions.Ship.Move.ReadValue<Vector2>().y;

        public float RotateInput => InputActions.Ship.Rotate.ReadValue<Vector2>().x;

        public void DisableInputs() 
        {
            InputActions.Ship.Disable();
        }
    }
}