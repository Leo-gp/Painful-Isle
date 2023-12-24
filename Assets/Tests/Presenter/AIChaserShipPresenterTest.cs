using System;
using Model.ShipModel;
using NSubstitute;
using NUnit.Framework;
using Presenter.ShipPresenter;
using View.ShipView;

namespace Tests.Presenter
{
    [TestFixture]
    public class AIChaserShipPresenterTest
    {
        [SetUp]
        public void SetUp()
        {
            _ship = Substitute.For<IChaserShip>();
            _shipView = Substitute.For<IChaserShipView>();

            _shipPresenter = new AIChaserShipPresenter(_ship, _shipView);

            var shipDeteriorationConfiguration = ShipPresenterFixture.ShipDeteriorationConfiguration;
            _ship.DeteriorationConfiguration.Returns(shipDeteriorationConfiguration);
        }

        private IChaserShip _ship;
        private IChaserShipView _shipView;

        private AIChaserShipPresenter _shipPresenter;

        [Test]
        public void HandleShipCollision_WhenCollidedShipIsNotPlayer_DoNotCallTakeDamage()
        {
            _ship.CurrentHealth.Returns(50f);

            var collidedShipView = Substitute.For<IShipView>();

            _shipPresenter.OnEnable();
            _shipView.OnCollidedWithShip += Raise.Event<Action<IShipView>>(collidedShipView);

            collidedShipView.ShipPresenter.DidNotReceive().TakeDamage(Arg.Any<float>());
            Assert.AreEqual(50f, _ship.CurrentHealth);
        }

        [Test]
        public void HandleShipCollision_WhenCollidedShipIsPlayer_CallTakeDamageOnCollidedShipAndSelf()
        {
            _ship.ExplosionDamage.Returns(10f);
            _ship.CurrentHealth.Returns(50f);

            var collidedShipView = Substitute.For<IPlayerShooterShipView>();

            _shipPresenter.OnEnable();
            _shipView.OnCollidedWithShip += Raise.Event<Action<IShipView>>(collidedShipView);

            collidedShipView.ShipPresenter.Received().TakeDamage(10f);
            Assert.AreEqual(0f, _ship.CurrentHealth);
        }
    }
}