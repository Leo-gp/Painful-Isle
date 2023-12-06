using Model.ShipModel;
using View.ShipView;

namespace Presenter.ShipPresenter
{
    public class ChaserShipPresenter : ShipPresenter
    {
        private readonly IShipView _shipView;
        private IShip _ship;

        public ChaserShipPresenter(IShip ship, IShipView shipView) : base(ship, shipView)
        {
            _ship = ship;
            _shipView = shipView;
        }

        private void Explode()
        {
        }
    }
}