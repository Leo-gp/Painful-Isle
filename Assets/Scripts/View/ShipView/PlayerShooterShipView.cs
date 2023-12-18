using Model.ShipModel;
using Model.ShipModel.ShipData;
using Model.ShipModel.ShipInputHandler;
using Presenter.ShipPresenter;
using UnityEngine;
using View.Input;

namespace View.ShipView
{
    public class PlayerShooterShipView : ShooterShipView, IPlayerShooterShipView
    {
        [SerializeField] private PlayerShooterShipData shipData;

        private IPlayerShooterShipInputHandler _shipInputHandler;
        private IPlayerShooterShipPresenter _shipPresenter;

        protected override void Awake()
        {
            base.Awake();
            _shipPresenter = ShipPresenter as IPlayerShooterShipPresenter;
            _shipInputHandler = ShipInputHandler as IPlayerShooterShipInputHandler;
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
            var shipPresenter = ShipPresenter as IPlayerShooterShipPresenter;
            return new PlayerShooterShipInputHandler(shipPresenter);
        }

        private IPlayerShooterShip CreateShip()
        {
            var maxHealth = shipData.Health;
            var moveSpeed = shipData.MoveSpeed;
            var rotationSpeed = shipData.RotationSpeed;
            var deteriorationConfiguration = shipData.DeteriorationConfiguration;
            var frontalShootCooldown = shipData.FrontalShootCooldown;
            var sideShootCooldown = shipData.SideShootCooldown;
            return new PlayerShooterShip
            (
                maxHealth,
                moveSpeed,
                rotationSpeed,
                deteriorationConfiguration,
                frontalShootCooldown,
                sideShootCooldown
            );
        }
    }
}