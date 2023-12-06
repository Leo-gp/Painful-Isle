using Model.ShipModel;
using View.ShipView;

namespace Presenter.ShipPresenter
{
    public class ShooterShipPresenter : ShipPresenter
    {
        private IShip _ship;
        private IShipView _shipView;

        public ShooterShipPresenter(IShip ship, IShipView shipView) : base(ship, shipView)
        {
            _ship = ship;
            _shipView = shipView;
        }

        private void Shoot()
        {
        }
    }
}