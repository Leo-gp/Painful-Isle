using Model.ShipModel;
using View.ShipView;

namespace Presenter.ShipPresenter
{
    public class ShooterShipPresenter : ShipPresenter
    {
        private Ship _ship;
        private ShipView _shipView;

        public ShooterShipPresenter(Ship ship, ShipView shipView) : base(ship, shipView)
        {
            _ship = ship;
            _shipView = shipView;
        }

        protected override void HandleMovement()
        {
        }

        private void Shoot()
        {
        }
    }
}