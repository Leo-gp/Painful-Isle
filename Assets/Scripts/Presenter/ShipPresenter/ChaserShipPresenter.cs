using Model.ShipModel;
using View.ShipView;

namespace Presenter.ShipPresenter
{
    public abstract class ChaserShipPresenter : ShipPresenter
    {
        private readonly IChaserShipView _chaserShipView;

        protected ChaserShipPresenter(IShip ship, IChaserShipView chaserShipView) : base(ship, chaserShipView)
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

        protected abstract void HandleShipCollision(IShipView collidedShipView);
    }
}