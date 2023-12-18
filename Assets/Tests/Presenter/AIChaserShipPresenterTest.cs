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
        }

        private IChaserShip _ship;
        private IChaserShipView _shipView;

        private AIChaserShipPresenter _shipPresenter;

        [Test]
        public void HandleShipCollision_WhenCollidedShipIsNotPlayer_DoNotApplyDamage()
        {
            var collidedShipView = Substitute.For<IShipView>();

            _shipPresenter.OnEnable();
            _shipView.OnCollidedWithShip += Raise.Event<Action<IShipView>>(collidedShipView);

            collidedShipView.ShipPresenter.DidNotReceive().TakeDamage(Arg.Any<float>());
            _shipPresenter.DidNotReceive().TakeDamage(Arg.Any<float>());
        }

        [Test]
        public void HandleShipCollision_WhenCollidedShipIsPlayer_DamageCollidedShipAndSelf()
        {
            _ship.ExplosionDamage.Returns(10f);
            _ship.CurrentHealth.Returns(50f);

            var collidedShipView = Substitute.For<IPlayerShooterShipView>();

            _shipPresenter.OnEnable();
            _shipView.OnCollidedWithShip += Raise.Event<Action<IShipView>>(collidedShipView);

            collidedShipView.ShipPresenter.Received().TakeDamage(10f);
            _shipPresenter.DidNotReceive().TakeDamage(50f);
        }
    }
}