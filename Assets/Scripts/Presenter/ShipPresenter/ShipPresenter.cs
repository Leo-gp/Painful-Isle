using Model.ShipModel;
using View.ShipView;

namespace Presenter.ShipPresenter
{
    public abstract class ShipPresenter : IShipPresenter
    {
        protected ShipPresenter(IShip ship, IShipView shipView)
        {
            Ship = ship;
            ShipView = shipView;
        }

        public IShip Ship { get; }

        public IShipView ShipView { get; }

        public void Move(float force)
        {
            ShipView.Move(force * Ship.MoveSpeed);
            Ship.Position = ShipView.Position;
        }

        public void Rotate(float angle)
        {
            ShipView.Rotate(angle * Ship.RotationSpeed);
            Ship.RotationAngle = ShipView.Rotation;
        }

        protected void Explode()
        {
            ShipView.Explode();
        }

        private void TakeDamage()
        {
        }
    }
}