using Model.ShipModel;
using Model.ShipModel.ShipData;
using Model.ShipModel.ShipInputHandler;
using Presenter.ShipPresenter;
using UnityEngine;

namespace View.ShipView
{
    public class AIShooterShipView : ShooterShipView
    {
        [SerializeField] private AIShooterShipData shipData;

        private IShip _target;

        protected override void Awake()
        {
            // TODO: Create factory to handle this
            Initialize(FindObjectOfType<PlayerShooterShipView>().ShipPresenter.Ship);

            base.Awake();
        }

        public void Initialize(IShip target)
        {
            _target = target;
        }

        protected override IShipPresenter CreateShipPresenter()
        {
            var ship = CreateShip();
            return new AIShooterShipPresenter(ship, this);
        }

        protected override IShipInputHandler CreateShipInputHandler()
        {
            var shipPresenter = ShipPresenter as IAIShooterShipPresenter;
            var ship = shipPresenter?.Ship as IAIShooterShip;
            return new AIShooterShipInputHandler(ship, shipPresenter);
        }

        private IAIShooterShip CreateShip() // TODO: Create factory to handle this
        {
            var maxHealth = shipData.Health;
            var moveSpeed = shipData.MoveSpeed;
            var rotationSpeed = shipData.RotationSpeed;
            var frontalShootCooldown = shipData.FrontalShootCooldown;
            var shootingRange = shipData.ShootingRange;
            return new AIShooterShip(maxHealth, moveSpeed, rotationSpeed, frontalShootCooldown, _target, shootingRange);
        }
    }
}