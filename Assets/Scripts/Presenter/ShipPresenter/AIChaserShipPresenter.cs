using Model.ShipModel;
using View.ShipView;

namespace Presenter.ShipPresenter
{
    public class AIChaserShipPresenter : ChaserShipPresenter
    {
        public AIChaserShipPresenter(IShip ship, IChaserShipView chaserShipView) : base(ship, chaserShipView)
        {
        }

        protected override void HandleShipCollision(IShipView collidedShipView)
        {
            if (collidedShipView is IPlayerShooterShipView) TakeDamage(Ship.CurrentHealth);
        }
    }
}