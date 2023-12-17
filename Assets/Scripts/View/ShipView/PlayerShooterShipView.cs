using Model.ShipModel;
using Model.ShipModel.ShipData;
using Model.ShipModel.ShipInputHandler;
using Presenter.ShipPresenter;
using UnityEngine;
using View.Input;

namespace View.ShipView
{
    public class PlayerShooterShipView : ShooterShipView
    {
        [SerializeField] private PlayerShooterShipData shipData;

        private PlayerShooterShipInputHandler _shipInputHandler;
        private PlayerShooterShipPresenter _shipPresenter;

        protected override void Awake()
        {
            base.Awake();
            _shipPresenter = ShipPresenter as PlayerShooterShipPresenter;
            _shipInputHandler = ShipInputHandler as PlayerShooterShipInputHandler;
        }

        protected override void Update()
        {
            base.Update();

            if (_shipInputHandler.RightShootInput) _shipPresenter.RightShoot();

            if (_shipInputHandler.LeftShootInput) _shipPresenter.LeftShoot();
        }

        protected override IShipPresenter CreateShipPresenter()
        {
            var ship = CreateShip();
            return new PlayerShooterShipPresenter(ship, this);
        }

        protected override IShipInputHandler CreateShipInputHandler()
        {
            return new PlayerShooterShipInputHandler();
        }

        private PlayerShooterShip CreateShip()
        {
            var maxHealth = shipData.Health;
            var moveSpeed = shipData.MoveSpeed;
            var rotationSpeed = shipData.RotationSpeed;
            var frontalShootCooldown = shipData.FrontalShootCooldown;
            var sideShootCooldown = shipData.SideShootCooldown;
            return new PlayerShooterShip(maxHealth, moveSpeed, rotationSpeed, frontalShootCooldown, sideShootCooldown);
        }
    }
}