using Model.ShipModel;
using UnityEngine;

namespace View.Input
{
    public class PlayerShooterShipInputHandler : IShooterShipInputHandler
    {
        private readonly InputActions _inputActions;

        public PlayerShooterShipInputHandler()
        {
            _inputActions = new InputActions();
            _inputActions.Ship.Enable();
        }

        public float MoveInput => _inputActions.Ship.Move.ReadValue<Vector2>().y;

        public float RotateInput => _inputActions.Ship.Rotate.ReadValue<Vector2>().x;

        public bool FrontalShootInput => _inputActions.Ship.FrontalShoot.WasPerformedThisFrame();

        public bool RightShootInput => _inputActions.Ship.RightShoot.WasPerformedThisFrame();

        public bool LeftShootInput => _inputActions.Ship.LeftShoot.WasPerformedThisFrame();
    }
}