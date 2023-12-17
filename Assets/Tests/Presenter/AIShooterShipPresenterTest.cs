using System.Numerics;
using Model.ShipModel;
using NSubstitute;
using NUnit.Framework;
using Presenter.ShipPresenter;
using View.ShipView;

namespace Tests.Presenter
{
    [TestFixture]
    public class AIShooterShipPresenterTest
    {
        [SetUp]
        public void SetUp()
        {
            _ship = Substitute.For<IAIShooterShip>();
            _shipView = Substitute.For<IShooterShipView>();
        }

        private IAIShooterShip _ship;
        private IShooterShipView _shipView;

        private AIShooterShipPresenter _shipPresenter;

        [Test]
        public void CanShoot_WhenRemainingTimeForShootIsNotZero_ShouldReturnFalse()
        {
            const float remainingTimeForShoot = 1f;

            _shipPresenter = new AIShooterShipPresenter(_ship, _shipView, remainingTimeForShoot);

            var canShoot = _shipPresenter.CanFrontalShoot();

            Assert.IsFalse(canShoot, "Should return false when remaining time for shoot is not zero.");
        }

        [Test]
        public void CanShoot_WhenRemainingTimeForShootIsZeroAndTargetIsNear_ShouldReturnTrue()
        {
            _shipPresenter = new AIShooterShipPresenter(_ship, _shipView);

            _ship.ShootingRange.Returns(1f);
            _ship.Position.Returns(new Vector2(0f, 0f));
            _ship.Target.Position.Returns(new Vector2(0f, 0.5f));

            var canShoot = _shipPresenter.CanFrontalShoot();

            Assert.IsTrue(canShoot,
                "Should return true when remaining time for shoot is zero and target is near.");
        }

        [Test]
        public void CanShoot_WhenRemainingTimeForShootIsZeroAndTargetIsNotNear_ShouldReturnFalse()
        {
            _shipPresenter = new AIShooterShipPresenter(_ship, _shipView);

            _ship.ShootingRange.Returns(1f);
            _ship.Position.Returns(new Vector2(0f, 0f));
            _ship.Target.Position.Returns(new Vector2(0f, 1.5f));

            var canShoot = _shipPresenter.CanFrontalShoot();

            Assert.IsFalse(canShoot,
                "Should return false when remaining time for shoot is zero and target is not near.");
        }

        [Test]
        public void CanMove_WhenTargetIsNear_ShouldReturnFalse()
        {
            _shipPresenter = new AIShooterShipPresenter(_ship, _shipView);

            _ship.ShootingRange.Returns(1f);
            _ship.Position.Returns(new Vector2(0f, 0f));
            _ship.Target.Position.Returns(new Vector2(0f, 0.5f));

            var canMove = _shipPresenter.CanMove();

            Assert.IsFalse(canMove, "Should return false when target is near.");
        }

        [Test]
        public void CanMove_WhenTargetIsNotNear_ShouldReturnTrue()
        {
            _shipPresenter = new AIShooterShipPresenter(_ship, _shipView);

            _ship.ShootingRange.Returns(1f);
            _ship.Position.Returns(new Vector2(0f, 0f));
            _ship.Target.Position.Returns(new Vector2(0f, 1.5f));

            var canMove = _shipPresenter.CanMove();

            Assert.IsTrue(canMove, "Should return true when target is not near.");
        }
    }
}