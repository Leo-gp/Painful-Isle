using System.Numerics;
using Model.ShipModel;
using NSubstitute;
using NUnit.Framework;
using Presenter.ShipPresenter;
using View.ShipView;

namespace Tests.Presenter
{
    [TestFixture]
    public class ShooterShipPresenterTest
    {
        [SetUp]
        public void SetUp()
        {
            _ship = Substitute.For<IShooterShip>();
            _shipView = Substitute.For<IShooterShipView>();

            _shipView.Position.Returns(new Vector2(0, 0));
            _shipView.UpVector.Returns(new Vector2(0, 1));
            _shipView.RightVector.Returns(new Vector2(1, 0));
            _ship.FrontalShootCooldown.Returns(FrontalShootCooldown);
        }

        private const float ShootPositionOffset = 0.7f;
        private const float FrontalShootCooldown = 2f;

        private IShooterShip _ship;
        private IShooterShipView _shipView;

        private ShooterShipPresenter _shipPresenter;

        [Test]
        public void FrontalShoot_WhenCannotFrontalShoot_ShouldNotCallViewShoot()
        {
            _shipPresenter = Substitute.ForPartsOf<ShooterShipPresenter>(_ship, _shipView, 0f);

            _ship.IsDestroyed.Returns(true);

            _shipPresenter.FrontalShoot();

            _shipView.DidNotReceive().Shoot(Arg.Any<Vector2>(), Arg.Any<Vector2>());
        }

        [Test]
        public void FrontalShoot_WhenCanFrontalShoot_ShouldCallViewShootAndResetRemainingTimeForShoot()
        {
            _shipPresenter = Substitute.ForPartsOf<ShooterShipPresenter>(_ship, _shipView, 0f);

            _ship.IsDestroyed.Returns(false);

            _shipPresenter.FrontalShoot();

            var direction = _shipView.UpVector;

            var offset = direction * ShootPositionOffset;
            var position = _shipView.Position + offset;

            _shipView.Received().Shoot(position, direction);
            Assert.AreEqual(_ship.FrontalShootCooldown, _shipPresenter.RemainingTimeForFrontalShoot);
        }

        [Test]
        public void UpdateShootCooldown_WhenRemainingTimeForShootIsNotZero_ShouldDecreaseRemainingTimeForShoot()
        {
            const float remainingTimeForFrontalShoot = 1f;

            _shipPresenter =
                Substitute.ForPartsOf<ShooterShipPresenter>(_ship, _shipView, remainingTimeForFrontalShoot);

            _shipPresenter.UpdateShootCooldown(1f);

            Assert.AreEqual(0f, _shipPresenter.RemainingTimeForFrontalShoot);
        }
    }
}