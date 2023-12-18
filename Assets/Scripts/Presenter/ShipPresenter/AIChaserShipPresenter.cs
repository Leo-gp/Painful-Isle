using Model.ShipModel;
using View.ShipView;

namespace Presenter.ShipPresenter
{
    public class AIChaserShipPresenter : ChaserShipPresenter
    {
        private readonly IChaserShip _ship;

        public AIChaserShipPresenter(IChaserShip ship, IChaserShipView chaserShipView) : base(ship, chaserShipView)
        {
            _ship = Ship as IChaserShip;
        }

        protected override void HandleShipCollision(IShipView collidedShipView)
        {
            if (collidedShipView is not IPlayerShooterShipView) return;

            collidedShipView.ShipPresenter.TakeDamage(_ship.ExplosionDamage);
            TakeDamage(_ship.CurrentHealth);
        }
    }
}