using System.Numerics;
using Model.ShipModel;
using NSubstitute;
using NUnit.Framework;
using Presenter.ShipPresenter;
using View.ShipView;

namespace Tests.Presenter
{
    public class PlayerShooterShipPresenterTest
    {
        private const float ShootPositionOffset = 0.7f;
        private const float SideShootCannonBallsOffset = 0.4f;

        private IPlayerShooterShip _ship;

        private PlayerShooterShipPresenter _shipPresenter;
        private IShooterShipView _shipView;

        [SetUp]
        public void SetUp()
        {
            _ship = Substitute.For<IPlayerShooterShip>();
            _shipView = Substitute.For<IShooterShipView>();

            _shipView.Position.Returns(new Vector2(0, 0));
            _shipView.UpVector.Returns(new Vector2(0, 1));
            _shipView.RightVector.Returns(new Vector2(1, 0));
        }

        [Test]
        public void RightShoot_WhenCannotSideShoot_ShouldNotCallViewShoot()
        {
            const float remainingTimeForSideShoot = 1f;

            _shipPresenter = new PlayerShooterShipPresenter(_ship, _shipView, 0f, remainingTimeForSideShoot);

            _shipPresenter.RightShoot();

            _shipView.DidNotReceive().Shoot(Arg.Any<Vector2>(), Arg.Any<Vector2>());
        }

        [Test]
        public void RightShoot_WhenCanSideShoot_ShouldCallViewShootForAllPositions()
        {
            _shipPresenter = new PlayerShooterShipPresenter(_ship, _shipView);

            _shipPresenter.RightShoot();

            var direction = _shipView.RightVector;
            VerifySideShootCallsViewShootWithExpectedParameters(direction);
        }

        [Test]
        public void LeftShoot_WhenCannotSideShoot_ShouldNotCallViewShoot()
        {
            const float remainingTimeForSideShoot = 1f;

            _shipPresenter = new PlayerShooterShipPresenter(_ship, _shipView, 0f, remainingTimeForSideShoot);

            _shipPresenter.LeftShoot();

            _shipView.DidNotReceive().Shoot(Arg.Any<Vector2>(), Arg.Any<Vector2>());
        }

        [Test]
        public void LeftShoot_WhenCanSideShoot_ShouldCallViewShootForAllPositions()
        {
            _shipPresenter = new PlayerShooterShipPresenter(_ship, _shipView);

            _shipPresenter.LeftShoot();

            var direction = -_shipView.RightVector;
            VerifySideShootCallsViewShootWithExpectedParameters(direction);
        }

        [Test]
        public void CanFrontalShoot_WhenRemainingTimeForFrontalShootIsZero_ShouldReturnTrue()
        {
            _shipPresenter = new PlayerShooterShipPresenter(_ship, _shipView);

            var canShoot = _shipPresenter.CanFrontalShoot();

            Assert.IsTrue(canShoot);
        }

        [Test]
        public void CanFrontalShoot_WhenRemainingTimeForFrontalShootIsPositive_ShouldReturnFalse()
        {
            const float remainingTimeForFrontalShoot = 1f;

            _shipPresenter = new PlayerShooterShipPresenter(_ship, _shipView, remainingTimeForFrontalShoot);

            var canShoot = _shipPresenter.CanFrontalShoot();

            Assert.IsFalse(canShoot);
        }

        [Test]
        public void UpdateShootCooldown_WhenRemainingTimeForFrontalShootIsNotZero_ShouldDecreaseRemainingTimeForShoot()
        {
            const float remainingTimeForFrontalShoot = 1f;

            _shipPresenter = new PlayerShooterShipPresenter(_ship, _shipView, remainingTimeForFrontalShoot);

            _shipPresenter.UpdateShootCooldown(1f);

            Assert.AreEqual(0f, _shipPresenter.RemainingTimeForFrontalShoot);
        }

        private void VerifySideShootCallsViewShootWithExpectedParameters(Vector2 direction)
        {
            var up = _shipView.UpVector;
            for (var i = -1; i <= 1; i++)
            {
                var offset = direction * ShootPositionOffset + up * i * SideShootCannonBallsOffset;
                var position = _shipView.Position + offset;
                _shipView.Received(1).Shoot(position, direction);
            }
        }
    }
}