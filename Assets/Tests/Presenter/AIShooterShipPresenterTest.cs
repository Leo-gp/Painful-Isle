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

        [TestCase(true, 0f, true, false)]
        [TestCase(false, 1f, true, false)]
        [TestCase(false, 0f, false, false)]
        [TestCase(false, 0f, true, true)]
        public void CanFrontalShootTests
        (
            bool shipIsDestroyed,
            float remainingTimeForFrontalShoot,
            bool targetIsNear,
            bool expected
        )
        {
            _ship.IsDestroyed.Returns(shipIsDestroyed);

            SetTargetDistance(targetIsNear);

            _shipPresenter = new AIShooterShipPresenter(_ship, _shipView, remainingTimeForFrontalShoot);

            var canShoot = _shipPresenter.CanFrontalShoot();

            Assert.AreEqual(expected, canShoot);
        }

        [Test]
        public void CanMove_WhenShipIsDestroyed_ReturnFalse()
        {
            _ship.IsDestroyed.Returns(true);

            _shipPresenter = new AIShooterShipPresenter(_ship, _shipView);

            var canMove = _shipPresenter.CanMove();

            Assert.IsFalse(canMove, "Should return false when ship is destroyed.");
        }

        [Test]
        public void CanMove_WhenTargetIsNear_ReturnFalse()
        {
            const bool targetIsNear = true;

            _shipPresenter = new AIShooterShipPresenter(_ship, _shipView);

            SetTargetDistance(targetIsNear);

            var canMove = _shipPresenter.CanMove();

            Assert.IsFalse(canMove, "Should return false when target is near.");
        }

        [Test]
        public void CanMove_WhenTargetIsNotNear_ShouldReturnTrue()
        {
            const bool targetIsNear = false;

            _shipPresenter = new AIShooterShipPresenter(_ship, _shipView);

            SetTargetDistance(targetIsNear);

            var canMove = _shipPresenter.CanMove();

            Assert.IsTrue(canMove, "Should return true when target is not near.");
        }

        private void SetTargetDistance(bool targetIsNear)
        {
            _ship.ShootingRange.Returns(1f);
            _ship.Position.Returns(new Vector2(0f, 0f));
            _ship.Target.Position.Returns(new Vector2(0f, targetIsNear ? 0.5f : 1.5f));
        }
    }
}