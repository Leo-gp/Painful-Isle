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
            _ship = Substitute.For<IShip>();
            _shipView = Substitute.For<IChaserShipView>();

            _shipPresenter = new AIChaserShipPresenter(_ship, _shipView);
        }

        private IShip _ship;
        private IChaserShipView _shipView;

        private AIChaserShipPresenter _shipPresenter;

        [Test]
        public void HandleShipCollision_WhenCollidedShipIsPlayer_CallChaserShipViewExplode()
        {
            var collidedShipView = Substitute.For<IPlayerShooterShipView>();

            _shipPresenter.OnEnable();
            _shipView.OnCollidedWithShip += Raise.Event<Action<IShipView>>(collidedShipView);

            _shipView.Received().Explode();
        }

        [Test]
        public void HandleShipCollision_WhenCollidedShipIsNotPlayer_DoNotCallChaserShipViewExplode()
        {
            var collidedShipView = Substitute.For<IShipView>();

            _shipPresenter.OnEnable();
            _shipView.OnCollidedWithShip += Raise.Event<Action<IShipView>>(collidedShipView);

            _shipView.DidNotReceive().Explode();
        }
    }
}