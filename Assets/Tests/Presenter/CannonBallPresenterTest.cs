using System;
using Model.CannonBallModel;
using NSubstitute;
using NUnit.Framework;
using Presenter.CannonBallPresenter;
using View.CannonBallView;
using View.ShipView;

namespace Tests.Presenter
{
    [TestFixture]
    public class CannonBallPresenterTest
    {
        [SetUp]
        public void SetUp()
        {
            _cannonBall = Substitute.For<ICannonBall>();
            _cannonBallView = Substitute.For<ICannonBallView>();

            _cannonBallPresenter = new CannonBallPresenter(_cannonBall, _cannonBallView);
        }

        private ICannonBall _cannonBall;
        private ICannonBallView _cannonBallView;

        private CannonBallPresenter _cannonBallPresenter;

        [Test]
        public void OnEnable_ShouldSubscribeToOnHitShipEventAndOnHitAnythingOtherThanShip()
        {
            _cannonBallPresenter.OnEnable();

            _cannonBallView.Received().OnHitShip += Arg.Any<Action<IShipView>>();
            _cannonBallView.Received().OnHitAnythingOtherThanShip += Arg.Any<Action>();
        }

        [Test]
        public void OnDisable_ShouldUnsubscribeFromOnHitShipEventAndOnHitAnythingOtherThanShip()
        {
            _cannonBallPresenter.OnDisable();

            _cannonBallView.Received().OnHitShip -= Arg.Any<Action<IShipView>>();
            _cannonBallView.Received().OnHitAnythingOtherThanShip -= Arg.Any<Action>();
        }

        [Test]
        public void HandleHitShip_WhenCollidedShipIsOwnerShip_DoNotCallTakeDamageNorExplode()
        {
            var collidedShipView = Substitute.For<IShipView>();
            _cannonBallView.OwnerShipView.Returns(collidedShipView);

            _cannonBallView.OnHitShip += Raise.Event<Action<IShipView>>(collidedShipView);

            collidedShipView.ShipPresenter.DidNotReceive().TakeDamage(Arg.Any<int>());
            _cannonBallView.DidNotReceive().Explode();
        }

        [Test]
        public void HandleHitShip_WhenCollidedShipIsNotOwnerShip_CallTakeDamageAndExplode()
        {
            var collidedShipView = Substitute.For<IShipView>();
            _cannonBallView.OwnerShipView.Returns(Substitute.For<IShipView>());

            _cannonBallPresenter.OnEnable();
            _cannonBallView.OnHitShip += Raise.Event<Action<IShipView>>(collidedShipView);

            collidedShipView.ShipPresenter.Received().TakeDamage(_cannonBall.Damage);
            _cannonBallView.Received().Explode();
        }

        [Test]
        public void HandleHitAnythingOtherThanShip_CallExplode()
        {
            _cannonBallPresenter.OnEnable();
            _cannonBallView.OnHitAnythingOtherThanShip += Raise.Event<Action>();

            _cannonBallView.Received().Explode();
        }
    }
}