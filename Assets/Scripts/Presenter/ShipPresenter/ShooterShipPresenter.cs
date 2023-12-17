using System;
using System.Numerics;
using Model.ShipModel;
using View.ShipView;

namespace Presenter.ShipPresenter
{
    public abstract class ShooterShipPresenter : ShipPresenter, IShooterShipPresenter
    {
        protected const float ShootPositionOffset = 0.7f;
        protected const float SideShootCannonBallsOffset = 0.4f;

        private readonly IShooterShip _ship;
        private readonly IShooterShipView _shipView;

        protected ShooterShipPresenter
        (
            IShooterShip ship,
            IShooterShipView shipView,
            float remainingTimeForShoot = 0f
        ) : base(ship, shipView)
        {
            _ship = Ship as IShooterShip;
            _shipView = ShipView as IShooterShipView;
            RemainingTimeForFrontalShoot = remainingTimeForShoot;
        }

        public float RemainingTimeForFrontalShoot { get; private set; }

        public void FrontalShoot()
        {
            if (!CanFrontalShoot()) return;
            var direction = _shipView.UpVector;
            var offset = direction * ShootPositionOffset;
            ShootInDirection(direction, offset);
            RemainingTimeForFrontalShoot = _ship.FrontalShootCooldown;
        }

        public abstract bool CanFrontalShoot();

        public virtual void UpdateShootCooldown(float elapsedTime)
        {
            RemainingTimeForFrontalShoot = MathF.Max(RemainingTimeForFrontalShoot - elapsedTime, 0f);
        }

        protected void ShootInDirection(Vector2 direction, Vector2 offset)
        {
            var position = _shipView.Position + offset;
            _shipView.Shoot(position, direction);
        }
    }
}