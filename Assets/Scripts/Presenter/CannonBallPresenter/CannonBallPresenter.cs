using Model.CannonBallModel;
using View.CannonBallView;
using View.ShipView;

namespace Presenter.CannonBallPresenter
{
    public class CannonBallPresenter : ICannonBallPresenter
    {
        private readonly ICannonBall _cannonBall;
        private readonly ICannonBallView _cannonBallView;

        public CannonBallPresenter(ICannonBall cannonBall, ICannonBallView cannonBallView)
        {
            _cannonBall = cannonBall;
            _cannonBallView = cannonBallView;
        }

        public void OnEnable()
        {
            _cannonBallView.OnHitShip += HandleHitShip;
            _cannonBallView.OnHitAnythingOtherThanShip += HandleHitAnythingOtherThanShip;
        }

        public void OnDisable()
        {
            _cannonBallView.OnHitShip -= HandleHitShip;
            _cannonBallView.OnHitAnythingOtherThanShip -= HandleHitAnythingOtherThanShip;
        }

        private void HandleHitShip(IShipView collidedShipView)
        {
            if (collidedShipView == _cannonBallView.OwnerShipView) return;

            collidedShipView.ShipPresenter.TakeDamage(_cannonBall.Damage);
            _cannonBallView.Explode();
        }

        private void HandleHitAnythingOtherThanShip()
        {
            _cannonBallView.Explode();
        }
    }
}