using System;
using System.Numerics;
using Model.ShipModel;
using View.ShipView;

namespace Presenter.ShipPresenter
{
    public class PlayerShooterShipPresenter : ShooterShipPresenter, IPlayerShooterShipPresenter
    {
        private readonly IPlayerShooterShip _ship;
        private readonly IShooterShipView _shipView;

        public PlayerShooterShipPresenter
        (
            IPlayerShooterShip ship,
            IShooterShipView shipView,
            float remainingTimeForFrontalShoot = 0f,
            float remainingTimeForSideShoot = 0f
        ) : base(ship, shipView, remainingTimeForFrontalShoot)
        {
            _ship = ship;
            _shipView = shipView;
            RemainingTimeForSideShoot = remainingTimeForSideShoot;
        }

        public float RemainingTimeForSideShoot { get; private set; }

        public void RightShoot()
        {
            if (!CanSideShoot()) return;
            var direction = _shipView.RightVector;
            TripleShootInDirection(direction);
            RemainingTimeForSideShoot = _ship.SideShootCooldown;
        }

        public void LeftShoot()
        {
            if (!CanSideShoot()) return;
            var direction = -_shipView.RightVector;
            TripleShootInDirection(direction);
            RemainingTimeForSideShoot = _ship.SideShootCooldown;
        }

        public override void UpdateShootCooldown(float elapsedTime)
        {
            base.UpdateShootCooldown(elapsedTime);
            RemainingTimeForSideShoot = MathF.Max(RemainingTimeForSideShoot - elapsedTime, 0f);
        }

        private bool CanSideShoot()
        {
            return RemainingTimeForSideShoot <= 0f;
        }

        private void TripleShootInDirection(Vector2 direction)
        {
            var up = _shipView.UpVector;
            for (var i = -1; i <= 1; i++)
            {
                var offset = direction * ShootPositionOffset + up * SideShootCannonBallsOffset * i;
                ShootInDirection(direction, offset);
            }
        }
    }
}