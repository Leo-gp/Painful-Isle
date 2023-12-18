using Model.ShipModel.ShipInputHandler;
using Presenter.ShipPresenter;
using UnityEngine;

namespace View.Input
{
    public abstract class PlayerShipInputHandler : IShipInputHandler
    {
        private readonly IShipPresenter _shipPresenter;

        protected readonly InputActions InputActions;

        protected PlayerShipInputHandler(IShipPresenter shipPresenter)
        {
            InputActions = new InputActions();
            InputActions.Ship.Enable();
            _shipPresenter = shipPresenter;
        }

        public float MoveInput => _shipPresenter.CanMove() ? InputActions.Ship.Move.ReadValue<Vector2>().y : 0f;

        public float RotateInput => _shipPresenter.CanRotate() ? InputActions.Ship.Rotate.ReadValue<Vector2>().x : 0f;
    }
}