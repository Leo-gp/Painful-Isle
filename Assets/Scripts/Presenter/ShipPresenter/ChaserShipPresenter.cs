using Model.ShipModel;
using View.ShipView;

namespace Presenter.ShipPresenter
{
    public class ChaserShipPresenter : ShipPresenter
    {
        private readonly IChaserShipView _chaserShipView;

        public ChaserShipPresenter(IShip ship, IChaserShipView chaserShipView) : base(ship, chaserShipView)
        {
            _chaserShipView = chaserShipView;
        }

        public void OnEnable()
        {
            _chaserShipView.OnCollidedWithShip += HandleShipCollision;
        }

        public void OnDisable()
        {
            _chaserShipView.OnCollidedWithShip -= HandleShipCollision;
        }

        private void HandleShipCollision(IShipView collidedShipView)
        {
            if (collidedShipView is PlayerShooterShipView) Explode();
        }
    }
}