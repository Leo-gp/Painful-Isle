using System;
using Model.ShipModel;
using NSubstitute;
using NUnit.Framework;
using Presenter.ShipPresenter;
using View.ShipView;

namespace Tests.Presenter
{
    [TestFixture]
    public class ChaserShipPresenterTest
    {
        [SetUp]
        public void SetUp()
        {
            _ship = Substitute.For<IShip>();
            _chaserShipView = Substitute.For<IChaserShipView>();

            _chaserShipPresenter = new ChaserShipPresenter(_ship, _chaserShipView);
        }

        private IShip _ship;
        private IChaserShipView _chaserShipView;

        private ChaserShipPresenter _chaserShipPresenter;

        [Test]
        public void OnEnable_ShouldSubscribeToOnCollidedWithShipEvent()
        {
            _chaserShipPresenter.OnEnable();

            _chaserShipView.Received().OnCollidedWithShip += Arg.Any<Action<IShipView>>();
        }

        [Test]
        public void OnDisable_ShouldUnsubscribeFromOnCollidedWithShipEvent()
        {
            _chaserShipPresenter.OnDisable();

            _chaserShipView.Received().OnCollidedWithShip -= Arg.Any<Action<IShipView>>();
        }

        [Test]
        public void HandleShipCollision_WhenCollidedShipIsPlayer_CallChaserShipViewExplode()
        {
            var collidedShipView = Substitute.For<PlayerShooterShipView>();

            _chaserShipPresenter.OnEnable();
            _chaserShipView.OnCollidedWithShip += Raise.Event<Action<IShipView>>(collidedShipView);

            _chaserShipView.Received(1).Explode();
        }

        [Test]
        public void HandleShipCollision_WhenCollidedShipIsNotPlayer_DoNotCallChaserShipViewExplode()
        {
            var collidedShipView = Substitute.For<IShipView>();

            _chaserShipPresenter.OnEnable();
            _chaserShipView.OnCollidedWithShip += Raise.Event<Action<IShipView>>(collidedShipView);

            _chaserShipView.DidNotReceive().Explode();
        }
    }
}