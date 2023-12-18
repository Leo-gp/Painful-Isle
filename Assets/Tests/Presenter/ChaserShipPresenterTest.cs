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
            _shipView = Substitute.For<IChaserShipView>();

            _shipPresenter = Substitute.ForPartsOf<ChaserShipPresenter>(_ship, _shipView);
        }

        private IShip _ship;
        private IChaserShipView _shipView;

        private ChaserShipPresenter _shipPresenter;

        [Test]
        public void OnEnable_ShouldSubscribeToOnCollidedWithShipEvent()
        {
            _shipPresenter.OnEnable();

            _shipView.Received().OnCollidedWithShip += Arg.Any<Action<IShipView>>();
        }

        [Test]
        public void OnDisable_ShouldUnsubscribeFromOnCollidedWithShipEvent()
        {
            _shipPresenter.OnDisable();

            _shipView.Received().OnCollidedWithShip -= Arg.Any<Action<IShipView>>();
        }

        /*[Test]
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
        }*/
    }
}