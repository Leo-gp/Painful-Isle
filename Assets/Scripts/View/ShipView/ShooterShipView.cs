using Model.ShipModel.ShipInputHandler;
using Presenter.ShipPresenter;
using UnityEngine;
using View.CannonBallView;
using Vector2 = System.Numerics.Vector2;

namespace View.ShipView
{
    [RequireComponent(typeof(CannonBallLauncherView))]
    public abstract class ShooterShipView : ShipView, IShooterShipView
    {
        private CannonBallLauncherView _cannonBallLauncherView;
        private IShooterShipInputHandler _shipInputHandler;
        private IShooterShipPresenter _shipPresenter;

        protected override void Awake()
        {
            base.Awake();
            _cannonBallLauncherView = GetComponent<CannonBallLauncherView>();
            _shipPresenter = ShipPresenter as IShooterShipPresenter;
            _shipInputHandler = ShipInputHandler as IShooterShipInputHandler;
        }

        protected override void Update()
        {
            base.Update();

            if (_shipInputHandler.FrontalShootInput) _shipPresenter.FrontalShoot();

            _shipPresenter.UpdateShootCooldown(Time.deltaTime);
        }

        public void Shoot(Vector2 position, Vector2 direction)
        {
            var pos = new UnityEngine.Vector2(position.X, position.Y);
            var dir = new UnityEngine.Vector2(direction.X, direction.Y);
            _cannonBallLauncherView.LaunchCannonBall(pos, dir, this);
        }
    }
}