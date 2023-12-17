using System;
using Model.ShipModel;
using Model.ShipModel.ShipData;
using Model.ShipModel.ShipInputHandler;
using Presenter.ShipPresenter;
using UnityEngine;

namespace View.ShipView
{
    public class ChaserShipView : ShipView, IChaserShipView
    {
        [SerializeField] private ShipData shipData;

        private ChaserShipPresenter _shipPresenter;
        private IShip _target;

        protected override void Awake()
        {
            // TODO: Create factory to handle this
            Initialize(FindObjectOfType<PlayerShooterShipView>().ShipPresenter.Ship);

            base.Awake();
            _shipPresenter = ShipPresenter as ChaserShipPresenter;
        }

        private void OnEnable()
        {
            _shipPresenter?.OnEnable();
        }

        private void OnDisable()
        {
            _shipPresenter?.OnDisable();
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.TryGetComponent(out ShipView shipView)) OnCollidedWithShip?.Invoke(shipView);
        }

        public event Action<IShipView> OnCollidedWithShip;

        public void Initialize(IShip target)
        {
            _target = target;
        }

        protected override IShipPresenter CreateShipPresenter()
        {
            var ship = CreateShip();
            return new ChaserShipPresenter(ship, this);
        }

        protected override IShipInputHandler CreateShipInputHandler()
        {
            var ship = ShipPresenter.Ship as IAIShip;
            return new AIShipInputHandler(ship);
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