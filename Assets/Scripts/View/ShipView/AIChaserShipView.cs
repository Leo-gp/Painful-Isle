using Model.ShipModel;
using Model.ShipModel.ShipData;
using Model.ShipModel.ShipInputHandler;
using Presenter.ShipPresenter;
using UnityEngine;

namespace View.ShipView
{
    public class AIChaserShipView : ChaserShipView
    {
        [SerializeField] private ChaserShipData shipData;

        private IShip _target;

        protected override void Awake()
        {
            _target = FindObjectOfType<PlayerShooterShipView>().ShipPresenter.Ship;

            base.Awake();
        }

        protected override IShipPresenter CreateShipPresenter()
        {
            var ship = CreateShip();
            return new AIChaserShipPresenter(ship, this);
        }

        protected override IShipInputHandler CreateShipInputHandler()
        {
            var ship = ShipPresenter.Ship as IAIShip;
            return new AIShipInputHandler(ship, ShipPresenter);
        }

        private IAIShip CreateShip()
        {
            var maxHealth = shipData.Health;
            var moveSpeed = shipData.MoveSpeed;
            var rotationSpeed = shipData.RotationSpeed;
            return new AIChaserShip(maxHealth, moveSpeed, rotationSpeed, _target);
        }
    }
}