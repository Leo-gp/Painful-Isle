using System.Numerics;
using Model.ShipModel;
using View.ShipView;

namespace Presenter.ShipPresenter
{
    public class AIShooterShipPresenter : ShooterShipPresenter, IAIShooterShipPresenter
    {
        private readonly IAIShooterShip _ship;

        public AIShooterShipPresenter
        (
            IAIShooterShip ship,
            IShooterShipView shipView,
            float remainingTimeForShoot = 0f
        ) : base(ship, shipView, remainingTimeForShoot)
        {
            _ship = Ship as IAIShooterShip;
        }

        public override bool CanFrontalShoot()
        {
            return base.CanFrontalShoot() && TargetIsNear();
        }

        public override bool CanMove()
        {
            return base.CanMove() && !TargetIsNear();
        }

        private bool TargetIsNear()
        {
            return Vector2.Distance(_ship.Position, _ship.Target.Position) <= _ship.ShootingRange;
        }
    }
}