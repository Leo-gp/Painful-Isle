using Model.ShipModel;
using View.ShipView;

namespace Presenter.ShipPresenter
{
    public abstract class ShipPresenter
    {
        private readonly IShipView _shipView;

        protected ShipPresenter(IShip ship, IShipView shipView)
        {
            Ship = ship;
            _shipView = shipView;
        }

        public IShip Ship { get; }

        public void HandleMovement(float moveInput)
        {
            _shipView.Move(moveInput * Ship.ShipData.MoveSpeed);
            Ship.Position = _shipView.Position;
        }

        public void HandleRotation(float rotationInput)
        {
            _shipView.Rotate(rotationInput * Ship.ShipData.RotationSpeed);
            Ship.RotationAngle = _shipView.Rotation;
        }

        private void TakeDamage()
        {
        }

        private void Die()
        {
        }
    }
}