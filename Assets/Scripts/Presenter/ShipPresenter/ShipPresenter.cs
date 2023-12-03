using Model.ShipModel;
using View.ShipView;

namespace Presenter.ShipPresenter
{
    public abstract class ShipPresenter
    {
        private Ship _ship;
        private ShipView _shipView;

        protected ShipPresenter(Ship ship, ShipView shipView)
        {
            _ship = ship;
            _shipView = shipView;
        }

        protected abstract void HandleMovement();

        private void HandleRotation()
        {
        }

        private void TakeDamage()
        {
        }

        private void Die()
        {
        }
    }
}